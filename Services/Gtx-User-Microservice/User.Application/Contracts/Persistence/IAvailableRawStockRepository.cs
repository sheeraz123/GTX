using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IAvailableRawStockRepository : IAsyncRepository<StockMaster>
    {
       Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);
    }
}
