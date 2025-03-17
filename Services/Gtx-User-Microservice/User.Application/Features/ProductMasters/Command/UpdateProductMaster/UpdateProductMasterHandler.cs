using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Application.Features.ProductCategories.Command.AddProductCategory;
using User.Domain.Entities;

namespace User.Application.Features.ProductMasters.Command.UpdateProductMaster
{
    public class UpdateProductMasterHandler : IRequestHandler<UpdateProductMasterCommand, UpdateProductMasterVm>
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IMapper _mapper;

        public UpdateProductMasterHandler(IProductMasterRepository productMasterRepository, IMapper mapper)
        {
            _productMasterRepository = productMasterRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductMasterVm> Handle(UpdateProductMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductMaster>(request);
            var isExits = await _productMasterRepository.GetAsync(s => s.Id != entity.Id && s.ProductName.ToLower() == entity.ProductName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateProductMasterVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Client Already exists"
                };
            }
            var result = _productMasterRepository.UpdateAsync(entity);
            return _mapper.Map<UpdateProductMasterVm>(result);
        }
    }
}


