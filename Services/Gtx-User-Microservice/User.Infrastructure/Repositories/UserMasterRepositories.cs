using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using User.Application.Features.UserMaster.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Common.Miscellaneous.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.UserMaster.GetUsersList;

namespace User.Infrastructure.Repositories
{
    public class UserMasterRepositories : RepositoryBase<UserMaster>, IUserMasterRepository
    {
        private readonly Token _token;
        public UserMasterRepositories(SqlContext dbContext, IOptions<Token> tokenOption) : base(dbContext)
        {
            _token = tokenOption.Value;
        }

        public async Task<(int totalRecords, IReadOnlyList<GetUserDetailsVm> userDetails)> GetUsersAsync(GetUserQuery request)
        {
            if (request.UserId > 0)
            {
                var result = await _dbContext.userMasterEntity.Where(u => u.Id == request.UserId)
                   .Include(u => u.userTypes)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetUserDetailsVm
                   {
                       Id = u.Id,
                       UserTypeId = u.UserTypeId,
                       UserType = u.userTypes.UserType,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Password = u.Password,
                       Email = u.Email,
                       Mobile = u.Mobile,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy
                   })
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else
            {
                var result = await _dbContext.userMasterEntity
                   .Include(u => u.userTypes)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetUserDetailsVm
                   {
                       Id = u.Id,
                       UserTypeId = u.UserTypeId,
                       UserType = u.userTypes.UserType,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Password = u.Password,
                       Email = u.Email,
                       Mobile = u.Mobile,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy
                   })
                   .ToListAsync();
                int totalRecords = _dbContext.userMasterEntity.Count();
                return (totalRecords, result);
              

            }

        }
        public async Task<UserMasterVm> ValidateLogin(UserMasterQuery request)
        {
            var allUserMaster = await GetAsync(x => x.Mobile == request.Username && x.Password == request.Password && x.Enabled == true);

            if (allUserMaster is not null && allUserMaster.Count > 0)
            {
                var result = allUserMaster.FirstOrDefault();
                var token = GenerateJwtToken(result);
                return new UserMasterVm
                {
                    AccessToken = token,
                    ExpiresIn = _token.Expiry,
                    TokenType = "Bearer",
                    UserId = result.Id,
                    Name = result.FirstName + " " + result.LastName,
                    UserType = _dbContext.userTypesEntity.Where(x => x.Id == result.UserTypeId).Select(x => x.UserType).FirstOrDefault()
                };
            }

            else
            {
                return new UserMasterVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Invalid Username or Password"
                };
            }
        }

        private string GenerateJwtToken(UserMaster user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            DateTime expiry = DateTime.Now.AddSeconds(_token.Expiry);
            var key = Encoding.ASCII.GetBytes(_token.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.Now.AddSeconds(_token.Expiry),
                Audience = _token.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
