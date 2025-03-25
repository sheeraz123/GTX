using MediatR;

namespace User.Application.Features.Stocks.StockMasters.Query.GetData
{
    public class GetQuery : IRequest<GetVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public decimal Id { get; set; }
    }
}
