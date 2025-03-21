using User.Application.Features.Stocks.StockInvoices.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IStockInvoiceRepository : IAsyncRepository<StockInvoice>
    {
        Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);

    }
}

