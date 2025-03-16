using AngleSharp.Dom;
using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ClientMasters.Command.AddClient;
using User.Application.Features.UserMaster.Command.AddUserMaster;
using User.Domain.Entities;

namespace User.Application.Features.ClientMasters.Command.UpdateClient
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, UpdateClientVm>
    {
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IClientMasterRepository clientMasterRepository, IMapper mapper)
        {
            _clientMasterRepository = clientMasterRepository;
            _mapper = mapper;
        }

        public async Task<UpdateClientVm> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ClientMaster>(request);
            var isExits = await _clientMasterRepository.GetAsync(s => s.Id != entity.Id && s.ClientName.ToLower() == entity.ClientName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateClientVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Client Already exists"
                };
            }
            var result = await _clientMasterRepository.UpdateAsync(entity);
            return _mapper.Map<UpdateClientVm>(result);
        }
    }
}
