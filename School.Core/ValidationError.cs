using FluentValidation;
using School.Core.Base;
using System.Net;

namespace School.Core
{
    public class ValidationError<T>
    {
        private readonly IValidator<T> _validator;
        private List<string> errors;
        public ValidationError(IValidator<T> validator)
        {
            _validator = validator;
            errors = new List<string>();
        }

        public async Task<bool> ValidateAsync(T request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return false;
            }
            return true;
        }
        public async Task<Response<string>> checkandreturn(T request, CancellationToken cancellationToken)
        {
            var res = await ValidateAsync(request, cancellationToken);
            if (!res)
            {
                return new Response<string>()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Validation failed",
                    Errors = errors
                };
            }
            return null;
        }

    }
}
