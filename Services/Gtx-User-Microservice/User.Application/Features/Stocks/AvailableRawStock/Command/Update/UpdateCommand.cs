using MediatR;
using Microsoft.AspNetCore.Http;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Update;

public class UpdateCommand : IRequest<UpdateVm>
{
    public  required decimal Id { get; set; }
    public required string BillNumber { get; set; }

    public required decimal ClientId { get; set; }
    public required string BillImage { get; set; }

    public string TransactionType { get; set; } = Common.Miscellaneous.Models.TransactionType.Earn;
    public bool Enabled { get; set; } = true;
    public bool Deleted { get; set; } = false;
    public required decimal CreatedBy { get; set; }

    public required decimal UpdatedBy { get; set; }

    public DateTime UpdationDate { get; set; } = DateTime.Now;
    //   public IFormFile? Image { get; set; }
    public required List<RawStocks> stocks { get; set; }
}
public class RawStocks
{
    public required decimal StockId { get; set; }
    public required List<UpdateTranaction> transactions { get; set; }
}
