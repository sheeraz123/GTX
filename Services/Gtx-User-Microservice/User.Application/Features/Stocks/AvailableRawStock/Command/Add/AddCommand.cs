using MediatR;
using Microsoft.AspNetCore.Http;


namespace User.Application.Features.Stocks.AvailableRawStock.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
     
        public required string BillNumber { get; set; }

        public required decimal ClientId { get; set; }
        public required string BillImage { get; set; }
       
        public string TransactionType { get; set; } = Common.Miscellaneous.Models.TransactionType.Earn;
        public bool Enabled { get; set; } = true;
        public bool Deleted { get; set; }=false;
        public required decimal CreatedBy { get; set; }
        //   public IFormFile? Image { get; set; }
        public required List<RawStocks> stocks { get; set; }
    }
    public class RawStocks
    {
        public required decimal StockId { get; set; }
        public required List<AddTranaction> transactions { get; set; }
    }

}
