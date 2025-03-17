using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Domain.Entities
{
    [Table("tbl_CountryMaster")]
    public class CountryMaster
    {
        [Key]
        public int Id { get; set; }
        public required string CountryName { get; set; }
        public required string? CountryCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public ICollection<ClientMaster> clientMasters { get; set; }
        //public ICollection<StateMaster> StateMasters{ get; set; }

        //public ICollection<CityMaster> cityMasters{ get; set; }
    }
}
