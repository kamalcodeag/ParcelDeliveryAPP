using FluentValidation;

namespace ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel
{
    public class CreateParcelCommandValidator : AbstractValidator<CreateParcelCommand>
    {
        public CreateParcelCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.AuthorId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}