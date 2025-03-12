using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.CountryMaster.Query
{
    public class GetCountryHandler : IRequestHandler<GetCountryQuery, IReadOnlyList<GetCountryVm>>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public GetCountryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IReadOnlyList<GetCountryVm>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            var result = await _countryRepository.GetAsync(s => s.Enabled == true);
            return _mapper.Map<IReadOnlyList<GetCountryVm>>(result);
        }
    }
}
