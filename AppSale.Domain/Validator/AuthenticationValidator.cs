using AppSale.Domain.Model.Request;
using FluentValidation;

namespace AppSale.Domain.Validator
{
    public class AuthenticationValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationValidator()
        {
            RuleFor(c => c.UserName).NotNull().WithMessage("Informe o Username");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("Informe o Password");
        }
    }
}
