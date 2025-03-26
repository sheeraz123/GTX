using Common.Miscellaneous.Models;
using User.Domain.Entities;

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
        public  string? BillNumber { get; set; }
        public  string? BillImage { get; set; }
        public  string? TransactionType { get; set; }
        public decimal? ReverseBillingId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public  bool Enabled { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
       
        public decimal ClientId { get; set; }
        public ClientMaster? clientMaster { get; set; }
        public ICollection<RawStockInvoice>? rawStockInvoices { get; set; }

    }
}
