using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Jwt.Query
{
    public class JwtQueryHandler : IRequestHandler<JwtQuery, JwtVm>
    {
        private readonly IMapper _mapper;
        public Task<JwtVm> Handle(JwtQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
