using AutoMapper;
using Common.Miscellaneous.Models;
using Common.Miscellaneous;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using Microsoft.Extensions.Options;

namespace User.Application.Features.Misc.ColorMasters.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly IColorMasterRepository _repository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public AddHandler(IColorMasterRepository repository, IMapper mapper, IOptions<ImageServer> imageServer)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ColorMaster>(request);
            var isExits = await _repository.GetAsync(s => s.ColorName == entity.ColorName);

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
