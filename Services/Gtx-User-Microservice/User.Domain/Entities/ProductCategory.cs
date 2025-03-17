using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities
{
    [Table("tbl_ProductCategory")]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public required string ProductCategoryName { get; set; }
        public  string? CategoryCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public ICollection<ProductMaster>? productMasters{ get; set; }
    }
}
