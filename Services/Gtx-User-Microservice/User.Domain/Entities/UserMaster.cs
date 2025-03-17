using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User.Domain.Entities
{

    [Table("tbl_UserMaster")]
    public class UserMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
      
        public  string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public decimal Mobile { get; set; }
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        [ForeignKey("userTypes")]
        public decimal UserTypeId { get; set; }
        public UserTypes userTypes { get; set; }
    }
  
}
