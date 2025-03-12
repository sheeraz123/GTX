using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.CompanyMaster.Query;
using User.Application.Features.UserMaster.GetUsersList;
using User.Application.Features.UserMaster.Query;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface ICompanyMasterRepository : IAsyncRepository<CompanyMaster>
    {
     
        Task<(int totalRecords, IReadOnlyList<GetCompanyDetailsVm> details)>    GetCompanyAsync(GetCompanyQuery request);
        
    }
}
