using Common.Miscellaneous.Models;

namespace User.Application.Features.Stocks.AvailableRawStock.Query.GetData
{
     public class GetVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetDetailsVm>? Details { get; set; }
    }
    public class GetDetailsVm 
    {
        public decimal Id { get; set; }
        public int StockCategoryId { get; set; }
        public required string StockName { get; set; }
        public required string StockDescription { get; set; }
        public string? StockCode { get; set; }
        public string? StockImage { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public Domain.Entities.StockCategory? stockCategory{ get; set; }
        public string? HsnCode { get; set; }

    }
}
