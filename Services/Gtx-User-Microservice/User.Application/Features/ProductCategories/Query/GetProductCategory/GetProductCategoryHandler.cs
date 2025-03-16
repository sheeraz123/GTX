using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ProductCategories.Query;
using User.Application.Features.ProductCategories.Query.GetProductCategory;

namespace User.Application.Features.ClientMasters.Query
{
    class GetProductCategoryHandler : IRequestHandler<GetProductCategoryQuery, GetProductCategoryVm>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetProductCategoryVm> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var (totalCount, result) = await _productCategoryRepository.GetProductCategoryAsync(request);
            return new GetProductCategoryVm()
            {
                TotalRecords = totalCount,
                Details = result

            };

        }
    }
}
