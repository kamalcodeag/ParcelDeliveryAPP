using FluentValidation;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAssigneeId
{
    public class GetParcelsByAssigneeIdQueryValidator : AbstractValidator<GetParcelsByAssigneeIdQuery>
    {
        public GetParcelsByAssigneeIdQueryValidator()
        {
            RuleFor(x => x.AssigneeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
