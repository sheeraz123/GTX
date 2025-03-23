using MediatR;

namespace User.Application.Features.Stocks.StockCategories.Command.Update
{
    public class UpdateCommand : IRequest<UpdateVm>
    {
        public required int id { get; set; }
        public required string StockName { get; set; }
        public required string StockCode { get; set; }
        public required bool Enabled { get; set; }
        public required bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }
        public required decimal UpdatedBy { get; set; }

        public required int CalculatePerPair { get; set; }  
        public  DateTime UpdationDate { get; set; } = DateTime.Now;
    }
}