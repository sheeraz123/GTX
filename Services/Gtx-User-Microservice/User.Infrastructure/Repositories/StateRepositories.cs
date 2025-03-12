using user.infrastructure;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Infrastructure.Repositories
{
    public class StateRepositories : RepositoryBase<StateMaster>, IStateRepository
    {
        public StateRepositories(SqlContext dbContext) : base(dbContext)
        {
        }

     
    }
}
