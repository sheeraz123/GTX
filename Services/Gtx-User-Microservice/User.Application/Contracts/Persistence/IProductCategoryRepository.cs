using User.Application.Features.ClientMasters.Query;
using User.Application.Features.ProductCategories.Query;
using User.Application.Features.ProductCategories.Query.GetProductCategory;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IProductCategoryRepository : IAsyncRepository<ProductCategory>
    {
        Task<int> AddProductCategoryAsync(ProductCategory productCategory);
        Task<(int totalRecords, IReadOnlyList<GetProductCategoryDetailsVm> details)> GetProductCategoryAsync(GetProductCategoryQuery request);
    }
}
