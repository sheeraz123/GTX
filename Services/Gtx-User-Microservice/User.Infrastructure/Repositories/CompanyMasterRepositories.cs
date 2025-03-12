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
using User.Application.Features.CompanyMaster.Query;

namespace User.Infrastructure.Repositories
{
    public class CompanyMasterRepositories : RepositoryBase<CompanyMaster>, ICompanyMasterRepository
    {
        public CompanyMasterRepositories(SqlContext dbContext) : base(dbContext)
        {

        }

        public async Task<(int totalRecords, IReadOnlyList<GetCompanyDetailsVm> details)> GetCompanyAsync(GetCompanyQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.companyMasterEntity.Where(u => u.Id == request.Id)
                                     .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetCompanyDetailsVm
                   {
                       Id = u.Id,
                       CompanyName = u.CompanyName,
                       Description = u.Description,
                       Address = u.Address,
                       CityId = u.CityId,
                       StateId = u.StateId,
                       CountryId = u.CountryId,
                       Pincode = u.Pincode,
                       Email = u.Email,
                       Mobile = u.Mobile,
                       AlternateMobile = u.AlternateMobile,
                       CompanyLogo1 = u.CompanyLogo1,
                       CompanyLogo2 = u.CompanyLogo2,
                       GST = u.GST,
                       IECNo = u.IECNo,
                       AadharNumber = u.AadharNumber,
                       PANCard = u.PANCard,
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
                var result = await _dbContext.companyMasterEntity
                                      .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetCompanyDetailsVm
                   {
                       Id = u.Id,
                       CompanyName = u.CompanyName,
                       Description = u.Description,
                       Address = u.Address,
                       CityId = u.CityId,
                       StateId = u.StateId,
                       CountryId = u.CountryId,
                       Pincode = u.Pincode,
                       Email = u.Email,
                       Mobile = u.Mobile,
                       AlternateMobile = u.AlternateMobile,
                       CompanyLogo1 = u.CompanyLogo1,
                       CompanyLogo2 = u.CompanyLogo2,
                       GST = u.GST,
                       IECNo = u.IECNo,
                       AadharNumber = u.AadharNumber,
                       PANCard = u.PANCard,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy
                   })
                   .ToListAsync();
                int totalRecords = _dbContext.companyMasterEntity.Count();
                return (totalRecords, result);


            }

        }



    }
}
