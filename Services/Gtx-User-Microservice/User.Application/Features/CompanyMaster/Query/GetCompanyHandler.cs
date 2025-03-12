using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.CompanyMaster.Query
{
    class GetClientHandler : IRequestHandler<GetCompanyQuery, GetCompanyVm>
    {
        private readonly ICompanyMasterRepository _companyMasterRepository;
        private readonly IMapper _mapper;

        public GetClientHandler(ICompanyMasterRepository companyMasterRepository, IMapper mapper)
        {
            _companyMasterRepository = companyMasterRepository;
            _mapper = mapper;
        }

        public async Task<GetCompanyVm> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var (totalCount, result)= await _companyMasterRepository.GetCompanyAsync(request);
            return new GetCompanyVm()
            {
                TotalRecords = totalCount,
                Details = result
                
            };

        }
    }
}
