using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ClientMasters.Command.AddClient;
using User.Domain.Entities;

namespace User.Application.Features.ProductCategories.Command.AddProductCategory
{
    public class AddProductCategoryHandler : IRequestHandler<AddProductCategoryCommand, AddProductCategoryVm>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public AddProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<AddProductCategoryVm> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductCategory>(request);
            var isExits = await _productCategoryRepository.GetAsync(s => s.ProductCategoryName.ToLower() == entity.ProductCategoryName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddProductCategoryVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Product Category Already exists"
                };
            }
            var result = await _productCategoryRepository.AddAsync(entity);          
            return _mapper.Map<AddProductCategoryVm>(result);
        }
    }
}
