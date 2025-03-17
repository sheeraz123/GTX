using MediatR;

namespace User.Application.Features.ProductMasters.Query.GetProductMaster
{
    public class GetProductMasterQuery : IRequest<GetProductMasterVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public int Id { get; set; }
    }
}


