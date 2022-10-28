using Identity.Data.Models;

namespace Identity.Logic.Services
{
    public interface IJWTService
    {
        string GenerateToken(IEnumerable<UserRolePermissionsModel> users);
    }
}
