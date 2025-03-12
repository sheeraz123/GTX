using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.UserMaster.Query;

namespace User.Application.Features.CompanyMaster.Query
{
    public class GetCompanyQuery : IRequest<GetCompanyVm>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Id { get; set; }
    }
}
