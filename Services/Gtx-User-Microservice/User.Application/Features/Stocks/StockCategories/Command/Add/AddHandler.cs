using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.Stocks.StockCategories.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly IStockCategoryRepository _repository;
        private readonly IMapper _mapper;

        public AddHandler(IStockCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockCategory>(request);
            var isExits = await _repository.GetAsync(s => s.StockName.ToLower() == entity.StockName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new AddVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Stock Category Already exists"
                };
            }
            var result = await _repository.AddAsync(entity);          
            return _mapper.Map<AddVm>(result);
        }
    }
}
