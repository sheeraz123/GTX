using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Features.UserMaster.Query;

namespace User.Application.Features.UserMaster.GetUsersList
{
    class GetUserHandler : IRequestHandler<GetUserQuery, GetUserVm>
    {
        private readonly IUserMasterRepository _userMasterRepository;
        private readonly IMapper _mapper;

        public GetUserHandler(IUserMasterRepository userMasterRepository, IMapper mapper)
        {
            _userMasterRepository = userMasterRepository;
            _mapper = mapper;
        }

        public async Task<GetUserVm> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result= await _userMasterRepository.GetUsersAsync(request);
            return new GetUserVm()
            {
                TotalRecords = result.Count,
                UserDetails = result
                
            };

        }
    }
}
