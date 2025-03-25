using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Stocks.AvailableRawStock.Query.GetData
{
    class GetHandler : IRequestHandler<GetQuery, GetVm>
    {
        private readonly IAvailableRawStockRepository _repository;
        private readonly IMapper _mapper;

        public GetHandler(IAvailableRawStockRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<GetVm> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
