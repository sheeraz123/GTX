using AutoMapper;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.Stocks.StockCategories.Command.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateVm>
    {
        private readonly IStockCategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateHandler(IStockCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<StockCategory>(request);
            var isExits = await _repository.GetAsync(s => s.Id != entity.Id && s.StockName.ToLower() == entity.StockName.ToLower());

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Client Already exists"
                };
            }
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UpdateVm>(result);
        }
    }
}
