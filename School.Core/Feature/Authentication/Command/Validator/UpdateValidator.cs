using FluentValidation;
using School.Core.Feature.Authentication.Command.Models;

namespace School.Core.Feature.Authentication.Command.Validator
{
    public class UpdateValidator : AbstractValidator<UpdateAsync>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Email).NotEmpty().Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
           .WithMessage("Invalid email format.");
            RuleFor(x => x.FullName).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}
