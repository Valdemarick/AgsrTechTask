using FluentValidation;
using MediatR;

namespace AgsrTechTask.Api.Features.PipelineBehaviours;

internal sealed class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidationPipelineBehaviour<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehaviour(
        ILogger<ValidationPipelineBehaviour<TRequest, TResponse>> logger,
        IEnumerable<IValidator<TRequest>> validators)
    {
        _logger = logger;
        _validators = validators;
    }
    
    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        _logger.LogDebug("Start processing validation for {RequestName}.", requestName);

        if (!_validators.Any())
        {
            _logger.LogDebug("There is no any validator for {RequestName}.", requestName);

            return await next();
        }

        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(validationContext, cancellationToken)));

        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToList();
        if (failures.Count == 0)
        {
            _logger.LogDebug("Validation for {RequestName} succeeded.", requestName);

            return await next();
        }

        _logger.LogWarning("Validation for {RequestName} failed.", requestName);

        throw new ValidationException(failures);
    }
}
