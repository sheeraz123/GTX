using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserMaster.Command.AddUserMaster
{
    public class AddUserMasterCommand : IRequest<AddUserMasterVm>
    {
       
        public decimal UserTypeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public decimal Mobile { get; set; }
        public string? Password { get; set; }       
        public required bool Enabled { get; set; }
        public required bool Deleted { get; set; }
      
    }
}
