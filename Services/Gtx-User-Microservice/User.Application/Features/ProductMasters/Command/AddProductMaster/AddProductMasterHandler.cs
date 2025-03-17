using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.ProductMasters.Command.AddProductMaster
{
    public class AddProductMasterHandler : IRequestHandler<AddProductMasterCommand, AddProductMasterVm>
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IMapper _mapper;

        public AddProductMasterHandler(IProductMasterRepository productMasterRepository, IMapper mapper)
        {
            _productMasterRepository = productMasterRepository;
            _mapper = mapper;
        }

        public async Task<AddProductMasterVm> Handle(AddProductMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductMaster>(request);
            var isExits = await _productMasterRepository.GetAsync(s => s.ProductName.ToLower() == entity.ProductName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddProductMasterVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Product Master Already exists"
                };
            }
            var filePath = await SaveFileAsync(request.Image,request.ProductCode);

            // Set the file path to the entity
            entity.ProductImage = Path.Combine(request.ProductCode,request.Image.FileName);
            var result = await _productMasterRepository.AddAsync(entity);
            return _mapper.Map<AddProductMasterVm>(result);
        }
        private async Task<string> SaveFileAsync(IFormFile file,string productCode)
        {
            
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            string path = Path.Combine(folderPath, productCode);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var filePath = Path.Combine(path, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}

