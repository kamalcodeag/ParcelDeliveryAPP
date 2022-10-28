using FluentValidation;

namespace Identity.Logic.Features.Users.Queries.GetUserWithRolePermissions
{
    public class GetUserWithRolePermissionsQueryValidator : AbstractValidator<GetUserWithRolePermissionsQuery>
    {
        public GetUserWithRolePermissionsQueryValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("{PropertyName} is not in the correct format.");
        }
    }
}
