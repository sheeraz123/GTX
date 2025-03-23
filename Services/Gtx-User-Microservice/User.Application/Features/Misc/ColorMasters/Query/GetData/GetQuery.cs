using MediatR;

namespace User.Application.Features.Misc.ColorMasters.Query.GetData
{
    public class GetQuery : IRequest<GetVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public int Id { get; set; }
    }
}
