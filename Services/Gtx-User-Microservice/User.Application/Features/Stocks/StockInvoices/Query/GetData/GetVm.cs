using Common.Miscellaneous.Models;

namespace User.Application.Features.Stocks.StockInvoices.Query.GetData
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
        public string? BillNumber { get; set; }

        public decimal ClientId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductCode { get; set; }
        public string? BillImage { get; set; }
        public string? HSNCode { get; set; }
        public decimal MRP { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdationDate { get; set; }
        public Domain.Entities.StockCategory? stockCategory{ get; set; }

        public Domain.Entities.ClientMaster? clientMaster{ get; set; }

    }
}
