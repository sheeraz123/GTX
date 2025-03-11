using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.UserMaster.GetUsersList;
using User.Application.Features.UserMaster.Query;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IUserMasterRepository : IAsyncRepository<UserMaster>
    {
        Task<UserMasterVm> ValidateLogin(UserMasterQuery request);

        Task<(int totalRecords, IReadOnlyList<GetUserDetailsVm> userDetails)> GetUsersAsync(GetUserQuery request);
        
    }
}
