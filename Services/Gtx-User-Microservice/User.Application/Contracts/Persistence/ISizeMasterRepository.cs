
using User.Application.Features.Misc.SizeMasters.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface ISizeMasterRepository : IAsyncRepository<SizeMaster>
    {
       Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);
    }
}
