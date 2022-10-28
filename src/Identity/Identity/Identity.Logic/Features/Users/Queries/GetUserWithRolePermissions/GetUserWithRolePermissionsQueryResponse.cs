using Identity.Logic.Responses;

namespace Identity.Logic.Features.Users.Queries.GetUserWithRolePermissions
{
    public class GetUserWithRolePermissionsQueryResponse : BaseResponse
    {
        public string? Token { get; set; }
    }
}
