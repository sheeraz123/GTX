using Common.Miscellaneous.Models;
using System.Runtime.ConstrainedExecution;
using User.Domain.Entities;
namespace User.Application.Features.ClientMaster.Query
{
    public class GetClientVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetClientDetailsVm>? Details { get; set; }
    }
    public class GetClientDetailsVm
    {
        public decimal Id { get; set; }

        public decimal CompanyId { get; set; }
        public string? ClientName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int Pincode { get; set; }
        public string? Email { get; set; }
        public int Mobile { get; set; }
        public int AlternateMobile { get; set; }
        public decimal AadharNumber { get; set; }
        public string? PANCard { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public User.Domain.Entities.CompanyMaster companyMaster { get; set; }
    }
}
