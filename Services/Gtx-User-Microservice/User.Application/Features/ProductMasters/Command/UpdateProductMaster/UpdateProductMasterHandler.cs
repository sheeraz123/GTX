using AutoMapper;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using User.Application.Contracts.Persistence;
using User.Application.Features.ProductCategories.Command.AddProductCategory;
using User.Domain.Entities;

namespace User.Application.Features.ProductMasters.Command.UpdateProductMaster
{
    public class UpdateProductMasterHandler : IRequestHandler<UpdateProductMasterCommand, UpdateProductMasterVm>
    {
        private readonly IProductMasterRepository _productMasterRepository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;
        public UpdateProductMasterHandler(IProductMasterRepository productMasterRepository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _productMasterRepository = productMasterRepository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
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
            if (request.Image != null)
            {
                var filePiath = await SaveFileAsync(request.Image, request.ProductCode);
                entity.ProductImage = Path.Combine(_imageServer.Path ?? "", request.ProductCode, request.Image.FileName);
            }

            var result = await _productMasterRepository.UpdateAsync(entity);
            return _mapper.Map<UpdateProductMasterVm>(result);
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


