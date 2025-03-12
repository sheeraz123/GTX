using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.UserMaster.Query;

namespace User.Application.Features.ClientMaster.Query
{
    class GetClientHandler : IRequestHandler<GetClientQuery, GetClientVm>
    {
        private readonly IClientMasterRepository _clientMasterRepository;
        private readonly IMapper _mapper;

        public GetClientHandler(IClientMasterRepository clientMasterRepository, IMapper mapper)
        {
            _clientMasterRepository = clientMasterRepository;
            _mapper = mapper;
        }

        public async Task<GetClientVm> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var (totalCount, result)= await _clientMasterRepository.GetClientAsync(request);
            return new GetClientVm()
            {
                TotalRecords = totalCount,
                Details = result
                
            };

        }
    }
}
