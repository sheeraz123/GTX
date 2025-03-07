using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using user.infrastructure;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Infrastructure.Repositories
{
    public class UserTypeRepositories : RepositoryBase<UserTypes>, IUserTypeRepository
    {
        public UserTypeRepositories(SqlContext dbContext) : base(dbContext)
        {
        }
    }
}
