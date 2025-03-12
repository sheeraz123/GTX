using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.CityMaster.Query
{
    public class GetCityVm :BaseResponse
    {
        public int Id { get; set; }
        public required string CityName { get; set; }
        public required string? CityCode { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;

    }
}
