using MediatR;

namespace User.Application.Features.UserMaster.Query
{
    public class UserMasterQuery : IRequest<UserMasterVm>
    {
        public required decimal Username{ get; set; }
        public required string? Password{ get; set; }    
    }
}
