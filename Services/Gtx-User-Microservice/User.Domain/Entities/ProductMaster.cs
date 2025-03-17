using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities
{
    [Table("tbl_Product")]
    public class ProductMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
        public required string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public required string ProductCode { get; set; }
        public required string HSNCode { get; set; }
        public required decimal MRP { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        [ForeignKey("productCategory")]
        public int ProductCategoryId { get; set; }
        public ProductCategory? productCategory { get; set; }
        public  string? ProductImage { get; set; }
    }
}
