using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.CityMaster.Query;
using User.Application.Features.CountryMaster.Query;

namespace User.Application.Features.CityMaster.Query
{
    public class GetCityHandler : IRequestHandler<GetCityQuery, IReadOnlyList<GetCityVm>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public GetCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IReadOnlyList<GetCityVm>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var result = await _cityRepository.GetAsync(s => s.Enabled == true && s.StateId==request.StateId);
            return _mapper.Map<IReadOnlyList<GetCityVm>>(result);
        }

       
    }
}
