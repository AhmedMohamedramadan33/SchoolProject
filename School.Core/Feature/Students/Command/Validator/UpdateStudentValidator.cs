using FluentValidation;
using School.Core.Feature.Students.Command.Models;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Command.Validator
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudent>
    {
        private readonly IStudentService _service;
        public UpdateStudentValidator(IStudentService service)
        {
            _service = service;
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(200);
            RuleFor(x => x.Name).MustAsync(async (model, key, CancellationToken) => !await _service.IsNameExistWithOther(model.StudID, key)).WithMessage("name is aleardy exist");
            RuleFor(x => x.Address).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.Phone).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.DID).NotEmpty().NotNull();
        }

    }
}
