using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ClientMasters.Query;
using User.Domain.Entities;

namespace User.Application.Features.ProductMasters.Query.GetProductMaster
{
    public class GetProductMasterHandler : IRequestHandler<GetProductMasterQuery, GetProductMasterVm>
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IMapper _mapper;

        public GetProductMasterHandler(IProductMasterRepository productMasterRepository, IMapper mapper)
        {
            _productMasterRepository = productMasterRepository;
            _mapper = mapper;
        }

        public async Task<GetProductMasterVm> Handle(GetProductMasterQuery request, CancellationToken cancellationToken)
        {
            var (totalCount, result) = await _productMasterRepository.GetProductMasterAsync(request);
            return new GetProductMasterVm()
            {
                TotalRecords = totalCount,
                Details = result

            };
        }
    }
}


