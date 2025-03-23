using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Stocks.StockMasters.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
        public required int StockCategoryId { get; set; }
        public required string StockName { get; set; }

        public required string StockDescription { get; set; }
        public required string StockCode { get; set; }
        public string? StockImage { get; set; }

        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }

        public IFormFile? Image { get; set; }
    }
}
