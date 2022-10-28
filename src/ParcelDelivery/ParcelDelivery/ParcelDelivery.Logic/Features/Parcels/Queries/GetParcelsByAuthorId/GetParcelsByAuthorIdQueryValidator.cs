using FluentValidation;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAuthorId
{
    public class GetParcelsByAuthorIdQueryValidator : AbstractValidator<GetParcelsByAuthorIdQuery>
    {
        public GetParcelsByAuthorIdQueryValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
