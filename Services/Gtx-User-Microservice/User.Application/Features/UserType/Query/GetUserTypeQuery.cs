using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserType.Query
{
    public class GetUserTypeQuery : IRequest<IReadOnlyList<GetUserTypeVm>>
    {
        public bool Enabled { get; set; } = true;
    }
}
