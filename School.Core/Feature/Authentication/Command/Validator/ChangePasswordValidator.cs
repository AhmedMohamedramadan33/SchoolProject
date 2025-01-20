using FluentValidation;
using School.Core.Feature.Authentication.Command.Models;

namespace School.Core.Feature.Authentication.Command.Validator
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.id).NotEmpty();
            RuleFor(x => x.CurrentPassword).NotEmpty();
            RuleFor(x => x.NewPassword).Matches(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{6,}$").NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword).NotEmpty();
        }
    }
}
