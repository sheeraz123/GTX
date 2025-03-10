using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Miscellaneous.Models
{
   public class BaseResponse
    {
        public string? ResponseCode { get; set; }= "0";
        public string? ResponseMessage { get; set; }= "Success";
        /// public string ErrorMessage { get; set; }
    }
}
