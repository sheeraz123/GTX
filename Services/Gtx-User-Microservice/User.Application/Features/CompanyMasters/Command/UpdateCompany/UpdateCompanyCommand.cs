using MediatR;

namespace User.Application.Features.CompanyMasters.Command.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<UpdateCompanyVm>
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string? Pincode { get; set; }
        public string? Email { get; set; }
        public decimal? Mobile { get; set; }
        public decimal? AlternateMobile { get; set; }
        public string? CompanyLogo1 { get; set; }
        public string? CompanyLogo2 { get; set; }
        public string? GST { get; set; }
        public string? IECNo { get; set; }
        public string? AadharNumber { get; set; }
        public string? PANCard { get; set; }
       
        public DateTime? UpdationDate { get; set; } = DateTime.Now;
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
      
        public decimal? UpdatedBy { get; set; }
        public decimal? createdBy { get; set; }
    }
}
