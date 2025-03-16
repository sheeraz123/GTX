using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.CompanyMasters.Query;

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
                    .Include(u => u.countryMaster)
                    .Include(u => u.cityMaster)
                    .Include(u => u.stateMaster)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetCompanyDetailsVm
                   {
                       Id = u.Id,
                       CompanyName = u.CompanyName,
                       Description = u.Description,
                       Address = u.Address,
                       CityId = u.CityId,
                       cityMaster = u.cityMaster,
                       StateId = u.StateId,
                       stateMaster = u.stateMaster,
                       CountryId = u.CountryId,
                       countryMaster = u.countryMaster,
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
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.companyMasterEntity.Where(u => u.CompanyName.StartsWith(request.Search))
                    .Include(u => u.countryMaster)
                    .Include(u => u.cityMaster)
                    .Include(u => u.stateMaster)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetCompanyDetailsVm
                   {
                       Id = u.Id,
                       CompanyName = u.CompanyName,
                       Description = u.Description,
                       Address = u.Address,
                       CityId = u.CityId,
                       cityMaster = u.cityMaster,
                       StateId = u.StateId,
                       stateMaster = u.stateMaster,
                       CountryId = u.CountryId,
                       countryMaster = u.countryMaster,
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
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else
            {
                var result = await _dbContext.companyMasterEntity
                    .Include(u => u.countryMaster)
                    .Include(u => u.cityMaster)
                    .Include(u => u.stateMaster)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .Select(u => new GetCompanyDetailsVm
                    {
                        Id = u.Id,
                        CompanyName = u.CompanyName,
                        Description = u.Description,
                        Address = u.Address,
                        CityId = u.CityId,
                        cityMaster = u.cityMaster,
                        StateId = u.StateId,
                        stateMaster = u.stateMaster,
                        CountryId = u.CountryId,
                        countryMaster = u.countryMaster,
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
                    .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.companyMasterEntity.Count();
                return (totalRecords, result);


            }

        }


    }
}
