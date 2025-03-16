using MediatR;

namespace User.Application.Features.ClientMasters.Query
{
    public class GetClientQuery : IRequest<GetClientVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public int Id { get; set; }
    }
}
