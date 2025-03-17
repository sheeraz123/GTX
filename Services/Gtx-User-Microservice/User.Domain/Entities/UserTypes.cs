using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities
{
    [Table("tbl_UserType")]
    public class UserTypes
    {
        [Key]
        public decimal Id { get; set; }
        public required string  UserType { get; set; }
        public required string? Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public ICollection<UserMaster> userMasters { get; set; }
    }
}
