using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Contracts.Persistence;
using User.Application.Features.Stocks.StockInvoices.Query.GetData;

namespace User.Infrastructure.Repositories
{
    public class StockInvoiceRepositories : RepositoryBase<StockInvoice>, IStockInvoiceRepository
    {
        public StockInvoiceRepositories(SqlContext dbContext) : base(dbContext)
        {
        }



        public async Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.stockInvoicesEntity.Where(u => u.Id == request.Id)
                  .Include(u => u.StockCategory)
                  .Include(u => u.clientMaster)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetDetailsVm
                   {
                       Id = u.Id,
                       BillNumber = u.BillNumber,
                       ClientId = u.ClientId,
                       clientMaster = u.clientMaster,
                       ProductName = u.ProductName,
                       ProductDescription = u.ProductDescription,
                       ProductCode = u.ProductCode,
                       StockCategoryId = u.StockCategoryId,
                       stockCategory = u.StockCategory,
                       HSNCode = u.HSNCode,
                       BillImage = u.BillImage,
                       MRP = u.MRP,
                       CreatedBy = u.CreatedBy,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.stockInvoicesEntity.Where(u => u.ProductName.StartsWith(request.Search))
                       .Include(u => u.StockCategory)
                  .Include(u => u.clientMaster)
                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                  .Select(u => new GetDetailsVm
                  {
                      Id = u.Id,
                      BillNumber = u.BillNumber,
                      ClientId = u.ClientId,
                      clientMaster = u.clientMaster,
                      ProductName = u.ProductName,
                      ProductDescription = u.ProductDescription,
                      ProductCode = u.ProductCode,
                      StockCategoryId = u.StockCategoryId,
                      stockCategory = u.StockCategory,
                      HSNCode = u.HSNCode,
                      BillImage = u.BillImage,
                      MRP = u.MRP,
                      CreatedBy = u.CreatedBy,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted
                  })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.stockInvoicesEntity
                            .Include(u => u.StockCategory)
                  .Include(u => u.clientMaster)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetDetailsVm
                   {
                       Id = u.Id,
                       BillNumber = u.BillNumber,
                       ClientId = u.ClientId,
                       clientMaster = u.clientMaster,
                       ProductName = u.ProductName,
                       ProductDescription = u.ProductDescription,
                       ProductCode = u.ProductCode,
                       StockCategoryId = u.StockCategoryId,
                       stockCategory = u.StockCategory,
                       HSNCode = u.HSNCode,
                       BillImage = u.BillImage,
                       MRP = u.MRP,
                       CreatedBy = u.CreatedBy,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted
                   })
                  .AsNoTracking()
                  .ToListAsync();
                int totalRecords = _dbContext.stockInvoicesEntity.Count();
                return (totalRecords, result);
            }
        }
    }
}

