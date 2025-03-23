using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.StockCategories.Query.GetData;


namespace User.Infrastructure.Repositories
{
    public class StockCategoryRepositories : RepositoryBase<StockCategory>, IStockCategoryRepository
    {
        public StockCategoryRepositories(SqlContext dbContext) : base(dbContext)
        {
        }


        public async Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.StockCategoriesEntity.Where(u => u.Id == request.Id)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetDetailsVm
                   {
                       Id = u.Id,
                       StockName = u.StockName,
                       StockCode = u.StockCode,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy,
                       CalculatePerPair = u.CalculatePerPair
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.StockCategoriesEntity.Where(u => u.StockName.StartsWith(request.Search))

                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(u => new GetDetailsVm
                 {
                     Id = u.Id,
                     StockName = u.StockName,
                     StockCode = u.StockCode,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted,
                     CreatedBy = u.CreatedBy,
                     UpdatedBy = u.UpdatedBy,

                     CalculatePerPair = u.CalculatePerPair
                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.StockCategoriesEntity
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                  .Select(u => new GetDetailsVm
                  {
                      Id = u.Id,
                      StockName = u.StockName,
                      StockCode = u.StockCode,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy,
                      CalculatePerPair = u.CalculatePerPair
                  })
                  .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.StockCategoriesEntity.Count();
                return (totalRecords, result);


            }

        }

    }
}
