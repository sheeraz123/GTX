
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IBillingRawMaterialRepository : IAsyncRepository<BillingRawMaterial>
    {
        Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);

    }
}
