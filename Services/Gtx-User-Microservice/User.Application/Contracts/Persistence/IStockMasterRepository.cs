using User.Application.Features.Stocks.StockMasters.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IStockMasterRepository : IAsyncRepository<StockMaster>
    {
       Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);
    }
}
