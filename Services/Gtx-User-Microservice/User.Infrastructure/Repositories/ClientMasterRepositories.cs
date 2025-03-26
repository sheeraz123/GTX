using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.ClientMasters.Query;

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
                    .Include(u => u.stateMaster)
                    .Include(u => u.cityMaster)
                    .Include(u => u.countryMaster)

                   .Select(u => new GetClientDetailsVm
                   {
                       Id = u.Id,
                       ClientName = u.ClientName,
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
                       stateMaster = u.stateMaster,
                       cityMaster = u.cityMaster,
                       countryMaster = u.countryMaster,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy,
                       Vendor = u.Vendor
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.clientMasterEntity.Where(u => u.ClientName.StartsWith(request.Search))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(u => u.companyMaster)
                .Include(u => u.stateMaster)
                .Include(u => u.cityMaster)
                .Include(u => u.countryMaster)

                 .Select(u => new GetClientDetailsVm
                 {
                     Id = u.Id,
                     ClientName = u.ClientName,
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
                     stateMaster = u.stateMaster,
                     cityMaster = u.cityMaster,
                     countryMaster = u.countryMaster,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted,
                     CreatedBy = u.CreatedBy,
                     UpdatedBy = u.UpdatedBy,
                     Vendor = u.Vendor
                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.clientMasterEntity
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(u => u.companyMaster)
                .Include(u => u.stateMaster)
                .Include(u => u.countryMaster)
                .Include(u => u.countryMaster)
                  
                  .Select(u => new GetClientDetailsVm
                  {
                      Id = u.Id,

                      ClientName = u.ClientName,
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
                      stateMaster = u.stateMaster,
                      cityMaster = u.cityMaster,
                      countryMaster = u.countryMaster,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy,
                      Vendor = u.Vendor
                  })
                  .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.clientMasterEntity.Count();
                return (totalRecords, result);


            }

        }


    }
}
