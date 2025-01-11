using FluentValidation;
using MediatR;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // إذا كان هناك Validators مسجلة للنوع TRequest
        if (_validators.Any())
        {
            // إنشاء ValidationContext
            var context = new ValidationContext<TRequest>(request);

            // تنفيذ جميع الـ Validators
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            //var failures = validationResults.Where(x => x.Errors.Count() > 0).SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

            // إذا كانت هناك أخطاء في التحقق من الصحة، نرمي استثناء
            if (failures.Any())
            {

                throw new ValidationException(failures);
            }
        }

        // إذا كانت البيانات صالحة، نمرر الطلب إلى الـ Handler التالي في الـ Pipeline
        return await next();
    }
}