using User.Application.Features.ProductMasters.Query.GetProductMaster;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IProductMasterRepository : IAsyncRepository<ProductMaster>
    {
     
        Task<(int totalRecords, IReadOnlyList<GetProductMasterDetailsVm> details)> GetProductMasterAsync(GetProductMasterQuery request);
    }
}

