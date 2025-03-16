using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ClientMasters.Command.UpdateClient;
using User.Domain.Entities;

namespace User.Application.Features.ProductCategories.Command.AddProductCategory
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, UpdateProductCategoryVm>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCategoryHandler(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductCategoryVm> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductCategory>(request);
            var isExits = await _productCategoryRepository.GetAsync(s => s.Id != entity.Id && s.ProductCategoryName.ToLower() == entity.ProductCategoryName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateProductCategoryVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Client Already exists"
                };
            }
            var result = await _productCategoryRepository.UpdateAsync(entity);
            return _mapper.Map<UpdateProductCategoryVm>(result);
        }
    }
}
