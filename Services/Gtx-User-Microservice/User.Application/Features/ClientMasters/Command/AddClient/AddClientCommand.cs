using MediatR;

namespace User.Application.Features.ClientMasters.Command.AddClient
{
    public class AddClientCommand : IRequest<AddClientVm>
    {
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
        public decimal? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool Vendor { get; set; }

    }
}
