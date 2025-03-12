using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.CompanyMaster.Query
{
    public class GetCompanyVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetCompanyDetailsVm> Details { get; set; }
    }
    public class GetCompanyDetailsVm
    {
        public decimal Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int Pincode { get; set; }
        public string? Email { get; set; }
        public int Mobile { get; set; }
        public int AlternateMobile { get; set; }
        public string? CompanyLogo1 { get; set; }
        public string? CompanyLogo2 { get; set; }
        public string? GST { get; set; }
        public string? IECNo { get; set; }
        public decimal AadharNumber { get; set; }
        public string? PANCard { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
