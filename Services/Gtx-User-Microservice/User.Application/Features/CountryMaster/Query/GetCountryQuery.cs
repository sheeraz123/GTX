using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.CountryMaster.Query
{
    public class GetCountryQuery : IRequest<IReadOnlyList<GetCountryVm>>
    {
    }
}
