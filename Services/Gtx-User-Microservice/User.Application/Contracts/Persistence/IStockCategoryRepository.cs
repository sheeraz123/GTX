using User.Application.Features.Stocks.StockCategories.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IStockCategoryRepository : IAsyncRepository<StockCategory>
    {
       Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);
    }
}
