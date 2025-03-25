using MediatR;
using Microsoft.AspNetCore.Http;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Update;

public class UpdateCommand : IRequest<UpdateVm>
{
    public  decimal? Id { get; set; }
    public required decimal StockId { get; set; }
    public required string BillNumber { get; set; }
    public required decimal ClientId { get; set; }
    public required string BillImage { get; set; }
 
    public string? StockImage { get; set; }
    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public required decimal CreatedBy { get; set; }
    public IFormFile? Image { get; set; }
    public required List<UpdateTranaction> transactions { get; set; }
}