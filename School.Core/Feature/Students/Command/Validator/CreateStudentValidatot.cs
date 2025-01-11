using FluentValidation;
using School.Core.Feature.Students.Command.Models;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Command.Validator
{
    public class CreateStudentValidatot : AbstractValidator<CreateStudent>
    {
        private readonly IStudentService _service;
        public CreateStudentValidatot(IStudentService service)
        {
            _service = service;
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.Name).MustAsync(async (key, CancellationToken) => !await _service.IsNameExist(key)).WithMessage("name is aleardy exist");
            RuleFor(x => x.Address).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.Phone).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.DID).NotEmpty().NotNull();

        }

    }
}
