using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    [Table("tbl_Stock_RawMaterial_Billing")]
    public class BillingRawMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public required string BillNumber { get; set; }
        public required string BillImage { get; set; }
        public required string TransactionType { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }       
        [ForeignKey("clientMaster")]
        public decimal ClientId { get; set; }
        public ClientMaster? clientMaster { get; set; }
        public ICollection<RawStockInvoice>? rawStockInvoices{ get; set; }
    }
}
