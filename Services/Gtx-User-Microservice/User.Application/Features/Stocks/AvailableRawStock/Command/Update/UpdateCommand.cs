using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Update;

public class UpdateCommand : IRequest<UpdateVm>
{
    public required decimal id { get; set; }
    public required int StockCategoryId { get; set; }
    public required string StockName { get; set; }

    public required string StockDescription { get; set; }
    public required string StockCode { get; set; }
    public string? StockImage { get; set; }

    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public required decimal CreatedBy { get; set; }

    public required decimal UpdatedBy { get; set; }
    public string? HsnCode { get; set; }
    public required DateTime UpdationDate { get; set; } = DateTime.Now;
    public IFormFile? Image { get; set; }
}