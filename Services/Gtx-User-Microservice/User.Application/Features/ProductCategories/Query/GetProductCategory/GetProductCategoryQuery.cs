using MediatR;
using User.Application.Features.ProductCategories.Query.GetProductCategory;

namespace User.Application.Features.ProductCategories.Query
{
    public class GetProductCategoryQuery : IRequest<GetProductCategoryVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public int Id { get; set; }
    }
}
