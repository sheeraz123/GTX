using AutoMapper;
using Common.Miscellaneous.Models;
using Common.Miscellaneous;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using Microsoft.Extensions.Options;

namespace User.Application.Features.Misc.SizeMasters.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly ISizeMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public AddHandler(ISizeMasterRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SizeMaster>(request);
            var isExits = await _repository.GetAsync(s => s.Size == entity.Size);

            if (isExits != null && isExits.Count > 0)
            {
                return new AddVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Record Already exists"
                };
            }
           
            var result = await _repository.AddAsync(entity);          
            return _mapper.Map<AddVm>(result);
        }
    }
}
