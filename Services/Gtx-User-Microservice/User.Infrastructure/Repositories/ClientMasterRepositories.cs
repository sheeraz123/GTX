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
using User.Application.Features.ClientMaster.Query;

namespace User.Infrastructure.Repositories
{
    public class ClientMasterRepositories : RepositoryBase<ClientMaster>, IClientMasterRepository
    {
        public ClientMasterRepositories(SqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<(int totalRecords, IReadOnlyList<GetClientDetailsVm> details)> GetClientAsync(GetClientQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.clientMasterEntity.Where(u => u.Id == request.Id)
                   .Include(u => u.companyMaster)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetClientDetailsVm
                   {
                       Id = u.Id,
                       CompanyId = u.CompanyId,
                       Description = u.Description,
                       Address = u.Address,
                       CityId = u.CityId,
                       StateId = u.StateId,
                       CountryId = u.CountryId,
                       Pincode = u.Pincode,
                       Email = u.Email,
                       Mobile = u.Mobile,
                       AlternateMobile = u.AlternateMobile,
                       AadharNumber = u.AadharNumber,
                       PANCard = u.PANCard,
                       companyMaster = u.companyMaster,
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
                var result = await _dbContext.clientMasterEntity
                   .Include(u => u.companyMaster)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                  .Select(u => new GetClientDetailsVm
                  {
                      Id = u.Id,
                      CompanyId = u.CompanyId,
                      Description = u.Description,
                      Address = u.Address,
                      CityId = u.CityId,
                      StateId = u.StateId,
                      CountryId = u.CountryId,
                      Pincode = u.Pincode,
                      Email = u.Email,
                      Mobile = u.Mobile,
                      AlternateMobile = u.AlternateMobile,
                      AadharNumber = u.AadharNumber,
                      PANCard = u.PANCard,
                      companyMaster = u.companyMaster,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy
                  })
                   .ToListAsync();
                int totalRecords = _dbContext.clientMasterEntity.Count();
                return (totalRecords, result);


            }

        }

    }
}
