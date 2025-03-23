using AutoMapper;
using Common.Miscellaneous;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.Extensions.Options;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.Stocks.StockMasters.Command.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateVm>
    {
        private readonly IStockMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;
        public UpdateHandler(IStockMasterRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<UpdateVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockMaster>(request);
            var isExits = await _repository.GetAsync(s => s.Id != entity.Id && s.StockName.ToLower() == entity.StockName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Record Already exists"
                };
            }
            if (request.Image != null)
            {
                var filePiath = await FileStorage.SaveFileAsync(request.Image, _imageServer.FileStoragePath, request.StockCode);
                entity.StockImage = Path.Combine(_imageServer.Path ?? "", request.StockCode, request.Image.FileName);
            }
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UpdateVm>(result);
        }
    }
}
