using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.CountryMaster.Query;

namespace User.Application.Features.StateMaster.Query
{
    public class GetStateQuery : IRequest<IReadOnlyList<GetStateVm>>
    {
        public int CountryId { get; set; }

        public GetStateQuery(int countryId)
        {
            CountryId = countryId;
        }
    }
}
