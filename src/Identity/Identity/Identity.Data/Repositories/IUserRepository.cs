using Identity.Data.Entities;
using Identity.Data.Models;

namespace Identity.Data.Repositories
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IReadOnlyList<User>> GetAllCourierUsersAsync();
        Task<IReadOnlyList<UserRolePermissionsModel>> GetUserWithRolePermissionsAsync(string username);
    }
}