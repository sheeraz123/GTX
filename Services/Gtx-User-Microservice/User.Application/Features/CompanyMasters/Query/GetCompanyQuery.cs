using MediatR;

namespace User.Application.Features.CompanyMasters.Query
{
    public class GetCompanyQuery : IRequest<GetCompanyVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public int Id { get; set; }
    }
}
