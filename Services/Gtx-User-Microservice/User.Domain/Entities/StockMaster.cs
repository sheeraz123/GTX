using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    [Table("tbl_Stock_Master")]
    public class StockMaster
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
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
        [ForeignKey("StockCategory")]
        public int StockCategoryId { get; set; }
        public StockCategory? StockCategory { get; set; }
        public  string? HsnCode { get; set; }

    }
}
