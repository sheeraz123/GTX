using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain.Entities
{
    [Table("tbl_ClientMaster")]
    public class ClientMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal Id { get; set; }
      
        public string? ClientName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
       
        
        [ForeignKey("countryMaster")]
        public int CountryId { get; set; }
        public CountryMaster? countryMaster { get; set; }
        public int Pincode { get; set; }
        public string? Email { get; set; }
        public decimal? Mobile { get; set; }
        public decimal? AlternateMobile { get; set; }
        public decimal AadharNumber { get; set; }
        public string? PANCard { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public bool Vendor { get; set; }
        [ForeignKey("companyMaster")]
        public decimal CompanyId { get; set; }
        public CompanyMaster? companyMaster{ get; set; }
        [ForeignKey("stateMaster")]
        public int StateId { get; set; }
        public StateMaster? stateMaster { get; set; }
        [ForeignKey("cityMaster")]
        public int CityId { get; set; }
        public CityMaster? cityMaster { get; set; }
    }
}
