using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.StateMaster.Query
{
    public class GetStateVm : BaseResponse
    {
        public int Id { get; set; }
        public required string StateName { get; set; }
        public required string? StateCode { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;

    }
}
