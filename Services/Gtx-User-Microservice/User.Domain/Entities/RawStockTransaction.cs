using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Domain.Entities
{
    [Table("tbl_Stock_RawMaterial_Transaction")]
    public class RawStockTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public required decimal MRP { get; set; }
        public required int Quantity { get; set; }
        public required int TaxCGST { get; set; }
        public required int TaxSGST { get; set; }
        public required decimal Amount { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
     
        public required decimal InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
       
        public RawStockInvoice? rawStockInvoice { get; set; }

        public  decimal ReverseInvoiceId { get; set; }
        [ForeignKey("SizeMaster")]
        public required int SizeId { get; set; }
        public SizeMaster? SizeMaster { get; set; }
        [ForeignKey("colorMaster")]
        public required int ColorId { get; set; }
        public ColorMaster? colorMaster{ get; set; }


    }
}
