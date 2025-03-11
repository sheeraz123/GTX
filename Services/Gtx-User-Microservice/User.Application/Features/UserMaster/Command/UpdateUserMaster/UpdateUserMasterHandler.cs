using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.UserMaster.Command.AddUserMaster;

namespace User.Application.Features.UserMaster.Command.UpdateUserMaster
{
    public class UpdateUserMasterHandler : IRequestHandler<UpdateUserMasterCommand, UpdateUserMasterVm>
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly IMapper _mapper;

        public UpdateUserMasterHandler(IUserMasterRepository userMasterRepository, IMapper mapper)
        {
            _userMasterRepository = userMasterRepository ?? throw new ArgumentNullException(nameof(userMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateUserMasterVm> Handle(UpdateUserMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User.Domain.Entities.UserMaster>(request);
            entity.UserName = entity.Mobile.ToString();
            var isExits = await _userMasterRepository.GetAsync(s => s.Mobile == entity.Mobile && s.Id != entity.Id);
            if (isExits != null && isExits.Count > 0)
            {
                return new UpdateUserMasterVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Mobile Number Already exists"
                };
            }
            var result = await _userMasterRepository.UpdateAsync(entity);
            return _mapper.Map<UpdateUserMasterVm>(result);
        }
    }
}
