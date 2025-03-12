using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.CountryMaster.Query;

namespace User.Application.Features.CityMaster.Query
{
    public class GetCityQuery : IRequest<IReadOnlyList<GetCityVm>>
    {
        public int StateId { get; set; }

        public GetCityQuery(int stateId)
        {
            StateId = stateId;
        }
    }
}
