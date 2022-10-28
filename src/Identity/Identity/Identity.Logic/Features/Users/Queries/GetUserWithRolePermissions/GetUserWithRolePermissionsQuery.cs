using MediatR;

namespace Identity.Logic.Features.Users.Queries.GetUserWithRolePermissions
{
    public class GetUserWithRolePermissionsQuery : IRequest<GetUserWithRolePermissionsQueryResponse>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
