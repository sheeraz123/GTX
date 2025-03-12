using user.infrastructure;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Infrastructure.Repositories
{
    public class CountryRepositories : RepositoryBase<CountryMaster>, ICountryRepository
    {
        public CountryRepositories(SqlContext dbContext) : base(dbContext)
        {
        }

     
    }
}
