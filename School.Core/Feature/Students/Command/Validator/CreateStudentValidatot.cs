using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Command.Models;
using School.Core.Resources;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Command.Validator
{
    public class CreateStudentValidatot : AbstractValidator<CreateStudent>
    {
        private readonly IStudentService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        public CreateStudentValidatot(IStudentService service, IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _service = service;
            _localizer = localizer;
            RuleFor(x => x.Name).NotEmpty().WithMessage($" {_localizer[SharedResourcesKeys.Name]}:{_localizer[SharedResourcesKeys.NotEmpty]}").NotNull().MaximumLength(200);
            RuleFor(x => x.Name).MustAsync(async (key, CancellationToken) => !await _service.IsNameExist(key)).WithMessage($" {_localizer[SharedResourcesKeys.Name]}:{_localizer[SharedResourcesKeys.Exist]}");
            RuleFor(x => x.Address).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.Phone).NotEmpty().NotNull().MaximumLength(500);
            RuleFor(x => x.DID).NotEmpty().WithMessage($" {_localizer[SharedResourcesKeys.DID]}:{_localizer[SharedResourcesKeys.NotEmpty]}").NotNull();
            RuleFor(x => x.DID).MustAsync(async (key, CancellationToken) => await _departmentService.checkdepartment(key)).
                When(x => x.DID != null).
                WithMessage("This department Not Exist");

        }

    }
}
