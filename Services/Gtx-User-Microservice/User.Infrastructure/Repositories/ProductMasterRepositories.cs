using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.ProductMasters.Query;
using User.Application.Features.ProductMasters.Query.GetProductMaster;

namespace User.Infrastructure.Repositories
{
    public class ProductMasterRepositories : RepositoryBase<ProductMaster>, IProductMasterRepository
    {
        public ProductMasterRepositories(SqlContext dbContext) : base(dbContext)
        {
        }



        public async Task<(int totalRecords, IReadOnlyList<GetProductMasterDetailsVm> details)> GetProductMasterAsync(GetProductMasterQuery request)
        {
            if (request.Id > 0)
            {
                var result = await _dbContext.productMasterEntity.Where(u => u.Id == request.Id)
                  .Include(u => u.productCategory)
                 
                   .Select(u => new GetProductMasterDetailsVm
                   {
                       Id = u.Id,
                       ProductName = u.ProductName,
                       ProductCode = u.ProductCode,
                       ProductCategoryId = u.ProductCategoryId,
                       productCategory = u.productCategory,
                       HSNCode = u.HSNCode,
                       ProductImage = u.ProductImage,
                       ProductDescription = u.ProductDescription,
                       MRP = u.MRP,
                       CreatedBy = u.CreatedBy,
                       UpdationDate = u.UpdationDate,
                       Enabled = u.Enabled,
                       Deleted = u.Deleted
                   })
                   .AsNoTracking()
                   .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var result = await _dbContext.productMasterEntity.Where(u => u.ProductName.StartsWith(request.Search))
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(u => u.productCategory)
                
                 .Select(u => new GetProductMasterDetailsVm
                 {
                     Id = u.Id,
                     ProductName = u.ProductName,
                     ProductCode = u.ProductCode,
                     ProductCategoryId = u.ProductCategoryId,
                     productCategory = u.productCategory,
                     HSNCode = u.HSNCode,
                     ProductImage = u.ProductImage,
                     ProductDescription = u.ProductDescription,
                     MRP = u.MRP,
                     CreatedBy = u.CreatedBy,
                     UpdationDate = u.UpdationDate,
                     Enabled = u.Enabled,
                     Deleted = u.Deleted
                 })
                 .AsNoTracking()
                 .ToListAsync();
                int totalRecords = result.Count;
                return (totalRecords, result);
            }
            else
            {
                var result = await _dbContext.productMasterEntity
                    .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                      .Include(u => u.productCategory)
             
                  .Select(u => new GetProductMasterDetailsVm
                  {
                      Id = u.Id,
                      ProductName = u.ProductName,
                      ProductCode = u.ProductCode,
                      ProductCategoryId = u.ProductCategoryId,
                      productCategory = u.productCategory,
                      HSNCode = u.HSNCode,
                      ProductImage = u.ProductImage,
                      ProductDescription = u.ProductDescription,
                      MRP = u.MRP,
                      CreatedBy = u.CreatedBy,
                      UpdationDate = u.UpdationDate,
                      Enabled = u.Enabled,
                      Deleted = u.Deleted
                  })
                  .AsNoTracking()
                  .ToListAsync();
                int totalRecords = _dbContext.productMasterEntity.Count();
                return (totalRecords, result);
            }
        }
    }
}

