using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.CompanyMasters.Command.AddCompany;
using User.Domain.Entities;

namespace User.Application.Features.CompanyMasters.Command.UpdateCompany
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, UpdateCompanyVm>
    {
        private readonly ICompanyMasterRepository _companyMasterRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyMasterRepository companyMasterRepository, IMapper mapper)
        {
            _companyMasterRepository = companyMasterRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCompanyVm> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyMasterEntity = _mapper.Map<CompanyMaster>(request);
            var result = await _companyMasterRepository.UpdateAsync(companyMasterEntity);
            return _mapper.Map<UpdateCompanyVm>(result);
          
        }
    }
}
