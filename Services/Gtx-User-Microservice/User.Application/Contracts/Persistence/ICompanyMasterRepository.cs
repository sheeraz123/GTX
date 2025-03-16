using User.Application.Features.CompanyMasters.Command.UpdateCompany;
using User.Application.Features.CompanyMasters.Query;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface ICompanyMasterRepository : IAsyncRepository<CompanyMaster>
    {
        Task<(int totalRecords, IReadOnlyList<GetCompanyDetailsVm> details)> GetCompanyAsync(GetCompanyQuery request);
       
    }
}
