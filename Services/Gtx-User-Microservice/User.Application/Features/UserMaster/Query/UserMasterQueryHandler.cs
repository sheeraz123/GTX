using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserMaster.Query
{
    public class UserMasterQueryHandler : IRequestHandler<UserMasterQuery, UserMasterVm>
    {
        private readonly IMapper _mapper;
        private readonly IUserMasterRepository _userMasterRepository;

        public UserMasterQueryHandler(IMapper mapper, IUserMasterRepository userMasterRepository = null)
        {
            _mapper = mapper;
            _userMasterRepository = userMasterRepository;
        }

        public async Task<UserMasterVm> Handle(UserMasterQuery request, CancellationToken cancellationToken)
        {
            var result = await _userMasterRepository.ValidateLogin(request);
            return _mapper.Map<UserMasterVm>(result);
        }
    }
}
