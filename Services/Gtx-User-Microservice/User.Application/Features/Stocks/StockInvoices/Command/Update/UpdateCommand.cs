using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Stocks.StockInvoices.Command.Update;

public class UpdateCommand : IRequest<UpdateVm>
{
    public required int id { get; set; }
    public required decimal StockCategoryId { get; set; }
    public required string BillNumber { get; set; }
    public required decimal ClientId { get; set; }

    public required string ProductName { get; set; }
    public required string ProductDescription { get; set; }
    public required string ProductCode { get; set; }
    public required string BillImage { get; set; }

    public required string HSNCode { get; set; }
    public required decimal MRP { get; set; }
    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public required decimal CreatedBy { get; set; }

    public required decimal UpdatedBy { get; set; }
    public required DateTime UpdationDate { get; set; } = DateTime.Now;
    public IFormFile? Image { get; set; }
}