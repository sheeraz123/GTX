using MediatR;

namespace User.Application.Features.ClientMasters.Command.UpdateClient
{
    public class UpdateClientCommand : IRequest<UpdateClientVm>
    {
        public int Id { get; set; }
        public decimal CompanyId { get; set; }
        public string ClientName { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string? Pincode { get; set; }
        public string? Email { get; set; }
        public decimal? Mobile { get; set; }
        public decimal? AlternateMobile { get; set; }
        public decimal? AadharNumber { get; set; }
        public string? PANCard { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }

        public decimal? UpdatedBy { get; set; }
        public decimal? createdBy { get; set; }
        public bool Vendor { get; set; }

        public DateTime? UpdationDate { get; set; } = DateTime.Now;
    }
}
