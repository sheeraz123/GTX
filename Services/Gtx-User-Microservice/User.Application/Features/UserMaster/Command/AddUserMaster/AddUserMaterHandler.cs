using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.UserMaster.Query;
using User.Domain.Entities;

namespace User.Application.Features.UserMaster.Command.AddUserMaster
{
    public class AddUserMaterHandler : IRequestHandler<AddUserMasterCommand, AddUserMasterVm>
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly IMapper _mapper;

        public AddUserMaterHandler(IUserMasterRepository userMasterRepository, IMapper mapper)
        {
            _userMasterRepository = userMasterRepository ?? throw new ArgumentNullException(nameof(userMasterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<AddUserMasterVm> Handle(AddUserMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User.Domain.Entities.UserMaster>(request);
            entity.UserName = entity.Mobile.ToString();
            var isExits = await _userMasterRepository.GetAsync(s => s.Mobile == entity.Mobile);

            if (isExits != null && isExits.Count > 0)
            {
                return new AddUserMasterVm()
                {
                    ResponseCode = "-1",
                    ResponseMessage = "Mobile Number Already exists"
                };
            }
            var result = await _userMasterRepository.AddAsync(entity);
            return _mapper.Map<AddUserMasterVm>(result);
        }
    }
}
