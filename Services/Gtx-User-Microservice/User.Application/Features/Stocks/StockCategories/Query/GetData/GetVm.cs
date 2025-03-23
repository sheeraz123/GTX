using Common.Miscellaneous.Models;

namespace User.Application.Features.Stocks.StockCategories.Query.GetData
{
     public class GetVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetDetailsVm>? Details { get; set; }
    }
    public class GetDetailsVm 
    {
        public int Id { get; set; }
        public required string StockName { get; set; }
        public string? StockCode { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } 
        public required bool Deleted { get; set; } 
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public required int CalculatePerPair { get; set; }
        
    }
}
