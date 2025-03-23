using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Misc.SizeMasters.Command.Add
{
    public class AddCommand : IRequest<AddVm>
    {
        public required int Size { get; set; }
        public string? SizeType { get; set; }

        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }
   
    }
}
