using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ClientMasters.Command.UpdateClient;
using User.Application.Features.UserMaster.Command.AddUserMaster;
using User.Domain.Entities;

namespace User.Application.Features.ClientMasters.Command.AddClient
{
    public class AddClientHandler : IRequestHandler<AddClientCommand, AddClientVm>
    {
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IMapper _mapper;

        public AddClientHandler(IClientMasterRepository clientMasterRepository, IMapper mapper)
        {
            _clientMasterRepository = clientMasterRepository;
            _mapper = mapper;
        }

        public async Task<AddClientVm> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ClientMaster>(request);
            var isExits = await _clientMasterRepository.GetAsync(s => s.ClientName.ToLower() == entity.ClientName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddClientVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Client Already exists"
                };
            }
            var result = await _clientMasterRepository.AddAsync(entity);
            return _mapper.Map<AddClientVm>(result);
        }
    }
}
