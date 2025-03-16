using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.ClientMasters.Query;
using User.Application.Features.ProductCategories.Query.GetProductCategory;
using User.Application.Features.ProductCategories.Query;

namespace User.Infrastructure.Repositories
{
    public class ProductCategoryRepositories : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepositories(SqlContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddProductCategoryAsync(ProductCategory productCategory)
        {
            await _dbContext.productCategoryEntity.AddAsync(productCategory);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<(int totalRecords, IReadOnlyList<GetProductCategoryDetailsVm> details)> GetProductCategoryAsync(GetProductCategoryQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.productCategoryEntity.Where(u => u.Id == request.Id)
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                   .Select(u => new GetProductCategoryDetailsVm
                   {
                       Id = u.Id,
                       ProductCategoryName = u.ProductCategoryName,
                       CategoryCode = u.CategoryCode,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted,
                       CreatedBy = u.CreatedBy,
                       UpdatedBy = u.UpdatedBy
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
                ;

            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.productCategoryEntity.Where(u => u.ProductCategoryName.StartsWith(request.Search))

                 .Skip((request.PageNumber - 1) * request.PageSize)
                 .Take(request.PageSize)
                 .Select(u => new GetProductCategoryDetailsVm
                 {
                     Id = u.Id,
                     ProductCategoryName = u.ProductCategoryName,
                     CategoryCode = u.CategoryCode,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted,
                     CreatedBy = u.CreatedBy,
                     UpdatedBy = u.UpdatedBy
                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.productCategoryEntity
                   .Skip((request.PageNumber - 1) * request.PageSize)
                   .Take(request.PageSize)
                  .Select(u => new GetProductCategoryDetailsVm
                  {
                      Id = u.Id,
                      ProductCategoryName = u.ProductCategoryName,
                      CategoryCode = u.CategoryCode,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted,
                      CreatedBy = u.CreatedBy,
                      UpdatedBy = u.UpdatedBy
                  })
                  .AsNoTracking()
                   .ToListAsync();
                int totalRecords = _dbContext.clientMasterEntity.Count();
                return (totalRecords, result);


            }

        }

    }
}
