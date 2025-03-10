using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.UserMaster.Query
{
    public class UserMasterQueryValidator : AbstractValidator<UserMasterQuery>
    {
        public UserMasterQueryValidator() {
            RuleFor(p => p.Username).NotEmpty().WithMessage("{mobile} is required");
            RuleFor(p=>p.Password).NotEmpty().WithMessage($"Password is required");
        }
    }
}
