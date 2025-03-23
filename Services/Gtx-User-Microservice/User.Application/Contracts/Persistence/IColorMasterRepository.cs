
using User.Application.Features.Misc.ColorMasters.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IColorMasterRepository : IAsyncRepository<ColorMaster>
    {
       Task<(int totalRecords, IReadOnlyList<GetDetailsVm> details)> GetDetails(GetQuery request);
    }
}
