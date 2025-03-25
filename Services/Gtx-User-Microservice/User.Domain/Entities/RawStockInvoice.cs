using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Domain.Entities
{
    [Table("tbl_Stock_RawMaterial_Invoice")]
    public class RawStockInvoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
  

        public  decimal? ReverseBillingId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        [ForeignKey("stockMaster")]
        public decimal StockId { get; set; }
        public StockMaster? stockMaster{ get; set; }
        [ForeignKey("BillingRawMaterial")]
        public required decimal BillingId { get; set; }
        public BillingRawMaterial? BillingRawMaterial{ get; set; }

    }
}
