using FluentValidation;

namespace AgsrTechTask.Api.Features.Patients.Queries.GetById;

internal sealed class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
