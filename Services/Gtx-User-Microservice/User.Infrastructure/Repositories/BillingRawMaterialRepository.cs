using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using user.infrastructure;
using Microsoft.EntityFrameworkCore;
using User.Application.Features.Stocks.AvailableRawStock.Query.GetData;
using User.Application.Features.Stocks.AvailableRawStock.Command.Add;

namespace User.Infrastructure.Repositories
{
    public class BillingRawMaterialRepository : RepositoryBase<BillingRawMaterial>, IBillingRawMaterialRepository
    {
        public BillingRawMaterialRepository(SqlContext dbContext) : base(dbContext)
        {
        }

     

     
    }
}
