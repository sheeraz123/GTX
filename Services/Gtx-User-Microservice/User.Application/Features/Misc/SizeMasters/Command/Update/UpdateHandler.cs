using AutoMapper;
using Common.Miscellaneous;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.Extensions.Options;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.Misc.SizeMasters.Command.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateVm>
    {
        private readonly ISizeMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;
        public UpdateHandler(ISizeMasterRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<UpdateVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SizeMaster>(request);
            var isExits = await _repository.GetAsync(s => s.Id != entity.Id && s.Size == entity.Size);

            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Record Already exists"
                };
            }
           
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UpdateVm>(result);
        }
    }
}
