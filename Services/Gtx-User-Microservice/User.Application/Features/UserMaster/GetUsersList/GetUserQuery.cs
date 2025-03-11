using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.UserMaster.Query;

namespace User.Application.Features.UserMaster.GetUsersList
{
    public class GetUserQuery : IRequest<GetUserVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int UserId { get; set; }
    }
}
