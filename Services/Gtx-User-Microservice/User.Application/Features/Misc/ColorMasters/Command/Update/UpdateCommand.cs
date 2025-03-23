using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.Misc.ColorMasters.Command.Update;

public class UpdateCommand : IRequest<UpdateVm>
{
    public required decimal id { get; set; }

    public required string ColorName { get; set; }

    public bool Enabled { get; set; }
    public bool Deleted { get; set; }
    public required decimal CreatedBy { get; set; }

    public required decimal UpdatedBy { get; set; }
    
    public  DateTime UpdationDate { get; set; } = DateTime.Now;

}