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
        public required string BillNumber { get; set; }
        public required string BillImage { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        [ForeignKey("StockCategory")]
        public int StockCategoryId { get; set; }
        public StockCategory? StockCategory { get; set; }
        [ForeignKey("clientMaster")]
        public decimal ClientId { get; set; }
        public ClientMaster? clientMaster { get; set; }
    }
}
