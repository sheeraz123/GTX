using AutoMapper;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.ProductMasters.Command.AddProductMaster
{
    public class AddProductMasterHandler : IRequestHandler<AddProductMasterCommand, AddProductMasterVm>
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IMapper _mapper;

        private readonly ImageServer _imageServer;
        public AddProductMasterHandler(IProductMasterRepository productMasterRepository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _productMasterRepository = productMasterRepository;
            _mapper = mapper;

            _imageServer = imageServer.Value;
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
            if (request.Image != null)
            {
                var filePath = await SaveFileAsync(request.Image, request.ProductCode);

                // Set the file path to the entity
                entity.ProductImage = Path.Combine(_imageServer.Path ?? "", request.ProductCode, request.Image.FileName);
            }
            var result = await _productMasterRepository.AddAsync(entity);
            return _mapper.Map<AddProductMasterVm>(result);
        }
        private async Task<string> SaveFileAsync(IFormFile file, string productCode)
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

