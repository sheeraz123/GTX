using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Stocks.StockInvoices.Query.GetData
{
    class GetHandler : IRequestHandler<GetQuery, GetVm>
    {
        private readonly IStockInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public GetHandler(IStockInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetVm> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var (totalCount, result) = await _repository.GetDetails(request);
            return new GetVm()
            {
                TotalRecords = totalCount,
                Details = result

            };

        }
    }
}
