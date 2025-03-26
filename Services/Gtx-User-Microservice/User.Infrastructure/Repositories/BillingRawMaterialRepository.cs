using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Infrastructure.Repositories
{
    public class BillingRawMaterialRepository : RepositoryBase<BillingRawMaterial>, IBillingRawMaterialRepository
    {
        public BillingRawMaterialRepository(SqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.billingRawMaterialsEntity.Where(u => u.Id == request.Id)
                .Include(u => u.clientMaster)
                .Include(u => u.RawStockInvoices)
               .ThenInclude(s => s.stockMaster)
                .ThenInclude(s => s.StockCategory)
                .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.SizeMaster)
                    .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.colorMaster)
                .Select(u => new GetDetailsVm
                {
                    Id = u.Id,
                    BillNumber = u.BillNumber,
                    BillImage = u.BillImage,
                    TransactionType = u.TransactionType,
                    ReverseBillingId = u.ReverseBillingId,
                    ClientId = u.ClientId,
                    clientMaster = u.clientMaster,
                    rawStockInvoices = u.RawStockInvoices,
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
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.billingRawMaterialsEntity.Where(u => u.BillNumber.ToString().StartsWith(request.Search))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(u => u.clientMaster)
                .Include(u => u.RawStockInvoices)
               .ThenInclude(s => s.stockMaster)
                .ThenInclude(s => s.StockCategory)
                .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.SizeMaster)
                    .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.colorMaster)
                .Select(u => new GetDetailsVm
                {
                    Id = u.Id,
                    BillNumber = u.BillNumber,
                    BillImage = u.BillImage,
                    TransactionType = u.TransactionType,
                    ReverseBillingId = u.ReverseBillingId,
                    ClientId = u.ClientId,
                    clientMaster = u.clientMaster,
                    rawStockInvoices = u.RawStockInvoices,
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
                var result = await _dbContext.billingRawMaterialsEntity
               .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(u => u.clientMaster)
                .Include(u => u.RawStockInvoices)
               .ThenInclude(s => s.stockMaster)
                .ThenInclude(s => s.StockCategory)
                .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.SizeMaster)
                    .Include(u => u.RawStockInvoices)
                .ThenInclude(u => u.RawStockTransactions)
                .ThenInclude(u => u.colorMaster)
                .Select(u => new GetDetailsVm
                {
                    Id = u.Id,
                    BillNumber = u.BillNumber,
                    BillImage = u.BillImage,
                    TransactionType = u.TransactionType,
                    ReverseBillingId = u.ReverseBillingId,
                    ClientId = u.ClientId,
                    clientMaster = u.clientMaster,
                    rawStockInvoices = u.RawStockInvoices,
                    CreationDate = u.CreationDate,
                    UpdationDate = u.UpdationDate,
                    Enabled = u.Enabled,
                    Deleted = u.Deleted,
                    CreatedBy = u.CreatedBy,
                    UpdatedBy = u.UpdatedBy,

                })
                .AsNoTracking()
                .ToListAsync();
                int totalRecords = _dbContext.billingRawMaterialsEntity.Count();
                return (totalRecords, result);


            }
        }
    }
}
