using FluentValidation;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelById
{
    public class GetParcelByIdQueryValidator : AbstractValidator<GetParcelByIdQuery>
    {
        public GetParcelByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
