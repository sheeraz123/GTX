using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.CountryMaster.Query
{
    public class GetCountryVm : BaseResponse
    {
        public int Id { get; set; }
        public required string CountryName { get; set; }
        public required string? CountryCode { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;

    }
}
