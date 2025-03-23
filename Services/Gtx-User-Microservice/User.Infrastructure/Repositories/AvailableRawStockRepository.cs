using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;

namespace User.Infrastructure.Repositories
{
    public class AvailableRawStockRepository : RepositoryBase<StockMaster>, IAvailableRawStockRepository
    {
        public AvailableRawStockRepository(SqlContext dbContext) : base(dbContext)
        {
        }

       
        public async Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.stockMastersEntity.Where(u => u.Id == request.Id)
                    .Include(i=>i.StockCategory)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetDetailsVm
                   {
                       Id = u.Id,
                       StockName = u.StockName,
                       stockCategory = u.StockCategory,
                       StockDescription=u.StockDescription,
                       StockCategoryId=u.StockCategoryId,
                       StockCode = u.StockCode,
                       StockImage=u.StockImage,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy,
                       HsnCode=u.HsnCode
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.stockMastersEntity.Where(u => u.StockName.StartsWith(request.Search))
                    .Include(i => i.StockCategory)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(u => new GetDetailsVm
                 {
                     Id = u.Id,
                     StockName = u.StockName,
                     stockCategory = u.StockCategory,
                     StockDescription = u.StockDescription,
                     StockCategoryId = u.StockCategoryId,
                     StockCode = u.StockCode,
                     StockImage = u.StockImage,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted,
                     CreatedBy = u.CreatedBy,
                     UpdatedBy = u.UpdatedBy,
                     HsnCode = u.HsnCode
                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.stockMastersEntity
                    .Include(i => i.StockCategory)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                  .Select(u => new GetDetailsVm
                  {
                      Id = u.Id,
                      StockName = u.StockName,
                      stockCategory = u.StockCategory,
                      StockDescription = u.StockDescription,
                      StockCategoryId = u.StockCategoryId,
                      StockCode = u.StockCode,
                      StockImage = u.StockImage,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy,
                      HsnCode = u.HsnCode
                  })
                  .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.stockMastersEntity.Count();
                return (totalRecords, result);


            }

        }

    }
}
