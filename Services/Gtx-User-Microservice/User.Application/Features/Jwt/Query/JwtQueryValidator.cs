using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Jwt.Query
{
    public class JwtQueryValidator : AbstractValidator<JwtQuery>
    {
        public JwtQueryValidator() {
            RuleFor(p => p.Username).NotEmpty().WithMessage("{Username} is required");
            RuleFor(p=>p.Password).NotEmpty().WithMessage($"Password is required");
        }
    }
}
