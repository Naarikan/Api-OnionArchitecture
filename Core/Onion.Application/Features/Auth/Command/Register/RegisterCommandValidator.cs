using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Onion.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator() {

            RuleFor(x => x.FullName)
                    .NotEmpty()
                    .MaximumLength(100)
                    .MinimumLength(2)
                    .WithName("İsim SOyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("Mail");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Şifre");

            RuleFor(x => x.ConfirmPassford)
                .NotEmpty()
                .Equal(x => x.Password)
                .MinimumLength(3)
                .MaximumLength(20)
                .WithName("Şifre Tekrar");


        }
    }
}
