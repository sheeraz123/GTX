using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Misc.ColorMasters.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
        public required string ColorName { get; set; }

        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }

    }
}
