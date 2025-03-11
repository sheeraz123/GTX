using Common.Miscellaneous.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserMaster.Query
{
    public class UserMasterVm : BaseResponse
    {
        public string? TokenType { get; set; }
        public int? ExpiresIn { get; set; }
        public string? AccessToken { get; set; }
        public string? UserType { get; set; }
        public decimal? UserId { get; set; }
        public string? Name { get; set; }
    }

}
