using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Infrastructure.Repositories
{
    public class RawStockInvoiceRepository : RepositoryBase<RawStockInvoice>, IRawStockInvoiceRepository
    {
        public RawStockInvoiceRepository(SqlContext dbContext) : base(dbContext)
        {
        }

     

     
    }
}
