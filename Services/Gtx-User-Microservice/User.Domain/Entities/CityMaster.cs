using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
 [Table("tbl_CityMaster")]
    public class CityMaster
    {
        [Key]
        public int Id { get; set; }
        public required string CityName { get; set; }
        public required string? CityCode { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        [ForeignKey("stateMaster")]
        public int StateId { get; set; }
        public StateMaster stateMaster{ get; set; }

        [ForeignKey("countryMaster")]
        public int CountryId { get; set; }
        public CountryMaster countryMaster { get; set; }
    }
}
