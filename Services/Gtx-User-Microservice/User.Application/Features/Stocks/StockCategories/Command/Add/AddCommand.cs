using MediatR;

namespace User.Application.Features.Stocks.StockCategories.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
        public required  string StockName { get; set; }
        public required  string StockCode { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required int CalculatePerPair { get; set; }
        public required decimal CreatedBy { get; set; }
    }
}
