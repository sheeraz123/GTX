using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Infrastructure.Repositories
{
    public class RawStockTransactionRepository : RepositoryBase<RawStockTransaction>, IRawStockTransactionRepository
    {
        public RawStockTransactionRepository(SqlContext dbContext) : base(dbContext)
        {
        }

     

     
    }
}
