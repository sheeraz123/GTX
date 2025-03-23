using AutoMapper;
using Common.Miscellaneous.Models;
using Common.Miscellaneous;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using Microsoft.Extensions.Options;

namespace User.Application.Features.Stocks.StockMasters.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly IStockMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public AddHandler(IStockMasterRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockMaster>(request);
            var isExits = await _repository.GetAsync(s => s.StockName.ToLower() == entity.StockName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Record Already exists"
                };
            }
            if (request.Image != null)
            {
                var filePiath = await FileStorage.SaveFileAsync(request.Image, request.StockCode);
                entity.StockImage = Path.Combine(_imageServer.Path ?? "", request.StockCode, request.Image.FileName);
            }
            var result = await _repository.AddAsync(entity);          
            return _mapper.Map<AddVm>(result);
        }
    }
}
