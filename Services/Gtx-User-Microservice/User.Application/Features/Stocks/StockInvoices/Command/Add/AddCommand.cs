using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Stocks.StockInvoices.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
        public required decimal StockCategoryId { get; set; }
        public required string BillNumber { get; set; }
        public required decimal ClientId { get; set; }

        public required string ProductName { get; set; }
        public required  string ProductDescription { get; set; }
        public required  string ProductCode { get; set; }
        public required string BillImage { get; set; }

        public required string HSNCode { get; set; }
        public required decimal MRP { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }
        public IFormFile? Image { get; set; }
    }
}
