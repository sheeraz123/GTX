using user.infrastructure;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Infrastructure.Repositories
{
    public class CityRepositories : RepositoryBase<CityMaster>, ICityRepository
    {
        public CityRepositories(SqlContext dbContext) : base(dbContext)
        {
        }

     
    }
}
