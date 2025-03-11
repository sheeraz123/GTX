using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Application.Features.UserMaster.Command.AddUserMaster;

namespace User.Application.Features.UserMaster.Command.UpdateUserMaster
{
    class UpdateUserMasterValidate : AbstractValidator<UpdateUserMasterCommand>
    {
        public UpdateUserMasterValidate()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.UserTypeId).NotEmpty().WithMessage("UserTypeId is required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
            RuleFor(x => x.Mobile).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        }
    }
}
