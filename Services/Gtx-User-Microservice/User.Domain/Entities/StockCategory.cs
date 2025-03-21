using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities
{
    [Table("tbl_StockCategory")]
    public class StockCategory
    {
        [Key]
        public int Id { get; set; }
        public required string StockName { get; set; }
        public  string? StockCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public ICollection<StockInvoice>? stockInvoices{ get; set; }
        public ICollection<StockMaster>? stockMaster{ get; set; }
    }
}
