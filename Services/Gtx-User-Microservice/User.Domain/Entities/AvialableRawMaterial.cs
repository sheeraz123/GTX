using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    [Table("tbl_Available_RawStock")]
    public class AvialableRawMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public decimal StockId { get; set; }
        public required long Quantity { get; set; }
     
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }      
        [ForeignKey("SizeMaster")]
        public required int SizeId { get; set; }
        public SizeMaster? SizeMaster { get; set; }
        [ForeignKey("colorMaster")]
        public required int ColorId { get; set; }
        public ColorMaster? colorMaster { get; set; }

    }
}
