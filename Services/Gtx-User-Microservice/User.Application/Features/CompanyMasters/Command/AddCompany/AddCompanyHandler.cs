using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.CompanyMasters.Command.AddCompany
{
    public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, AddCompanyVm>
    {
        private readonly ICompanyMasterRepository _companyMasterRepository;
        private readonly IMapper _mapper;

        public AddCompanyHandler(ICompanyMasterRepository companyMasterRepository, IMapper mapper)
        {
            _companyMasterRepository = companyMasterRepository ?? throw new ArgumentNullException(nameof(companyMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AddCompanyVm> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CompanyMaster>(request);
            var result = await _companyMasterRepository.AddAsync(entity);
                return _mapper.Map<AddCompanyVm>(result);
        }
    }
}
