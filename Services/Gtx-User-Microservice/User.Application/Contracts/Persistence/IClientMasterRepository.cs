using User.Application.Features.ClientMasters.Command.AddClient;
using User.Application.Features.ClientMasters.Command.UpdateClient;
using User.Application.Features.ClientMasters.Query;
using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IClientMasterRepository : IAsyncRepository<ClientMaster>
    {

        Task<(int totalRecords, IReadOnlyList<GetClientDetailsVm> details)> GetClientAsync(GetClientQuery request);
     
        
    }
}
