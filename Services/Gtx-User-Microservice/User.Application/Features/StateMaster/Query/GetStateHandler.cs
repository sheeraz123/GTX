using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.CountryMaster.Query;

namespace User.Application.Features.StateMaster.Query
{
    public class GetStateHandler : IRequestHandler<GetStateQuery, IReadOnlyList<GetStateVm>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public GetStateHandler(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository ?? throw new ArgumentNullException(nameof(stateRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IReadOnlyList<GetStateVm>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var result = await _stateRepository.GetAsync(s => s.Enabled == true && s.CountryId == request.CountryId);
            return _mapper.Map<IReadOnlyList<GetStateVm>>(result);
        }
    }
}
