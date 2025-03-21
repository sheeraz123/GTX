using AutoMapper;
using Common.Miscellaneous.Models;
using Common.Miscellaneous;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using Microsoft.Extensions.Options;

namespace User.Application.Features.Stocks.StockInvoices.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly IStockInvoiceRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public AddHandler(IStockInvoiceRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockInvoice>(request);
            var isExits = await _repository.GetAsync(s => s.BillNumber.ToLower() == entity.BillNumber.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Stock Category Already exists"
                };
            }
            if (request.Image != null)
            {
                var filePiath = await FileStorage.SaveFileAsync(request.Image, request.ProductCode);
                entity.BillImage = Path.Combine(_imageServer.Path ?? "", request.ProductCode, request.Image.FileName);
            }
            var result = await _repository.AddAsync(entity);          
            return _mapper.Map<AddVm>(result);
        }
    }
}
