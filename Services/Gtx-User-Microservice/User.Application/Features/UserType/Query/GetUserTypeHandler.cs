using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.UserType.Query
{
    public class GetUserTypeHandler : IRequestHandler<GetUserTypeQuery, IReadOnlyList<GetUserTypeVm>>
    {
        private readonly IUserTypeRepository userTypeRepository;
        private readonly IMapper mapper;
        public GetUserTypeHandler(IUserTypeRepository userTypeRepository, IMapper mapper)
        {
            this.userTypeRepository = userTypeRepository;
            this.mapper = mapper;
        }


        async Task<IReadOnlyList<GetUserTypeVm>> IRequestHandler<GetUserTypeQuery, IReadOnlyList<GetUserTypeVm>>.Handle(GetUserTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await userTypeRepository.GetAllAsync();
            return mapper.Map<IReadOnlyList<GetUserTypeVm>>(result);

        }
    }
}
