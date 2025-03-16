using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    [Table("tbl_StateMaster")]
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        public required string StateName { get; set; }
        public required string? StateCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        [ForeignKey("countryMaster")]
        public int CountryId { get; set; }
        public CountryMaster countryMaster { get; set; }
        //public ICollection<CityMaster> CityMasters { get; set; }
        //public ICollection<CompanyMaster> CompanyMasters { get; set; }
        public ICollection<ClientMaster> clientMasters{ get; set; }
    }
}
