using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Misc.SizeMasters.Query.GetData;

namespace User.Infrastructure.Repositories
{
    public class SizeMasterRepositories : RepositoryBase<SizeMaster>, ISizeMasterRepository
    {
        public SizeMasterRepositories(SqlContext dbContext) : base(dbContext)
        {
        }


        public async Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.sizeMasterEntity.Where(u => u.Id == request.Id)
                                     
                   .Select(u => new GetDetailsVm
                   {
                       Id = u.Id,
                       Size = u.Size,
                       SizeType = u.SizeType,
                       CreationDate=u.CreationDate,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy,

                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.sizeMasterEntity.Where(u => u.Size.ToString().StartsWith(request.Search))

                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(u => new GetDetailsVm
                 {
                     Id = u.Id,
                     Size = u.Size,
                     SizeType = u.SizeType,
                     CreationDate = u.CreationDate,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted,
                     CreatedBy = u.CreatedBy,
                     UpdatedBy = u.UpdatedBy,

                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.sizeMasterEntity

                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                  .Select(u => new GetDetailsVm
                  {
                      Id = u.Id,
                      Size = u.Size,
                      SizeType = u.SizeType,
                      CreationDate = u.CreationDate,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy,

                  })
                  .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.sizeMasterEntity.Count();
                return (totalRecords, result);


            }

        }

    }
}
