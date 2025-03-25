using User.Application.Features.Stocks.AvailableRawStock.Command.Add;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IRawStockTransactionRepository : IAsyncRepository<RawStockTransaction>
    {
     
    }
}
