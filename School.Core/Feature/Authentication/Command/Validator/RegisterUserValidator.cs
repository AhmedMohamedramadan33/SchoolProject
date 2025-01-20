using FluentValidation;
using School.Core.Feature.Authentication.Command.Models;

namespace School.Core.Feature.Authentication.Command.Validator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUser>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .WithMessage("Invalid email format.");
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{6,}$");
            RuleFor(x => x.PasswordConfirmed).Equal(x => x.Password).NotEmpty();




        }
    }
}
