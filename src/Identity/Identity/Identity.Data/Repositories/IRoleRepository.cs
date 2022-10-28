using Identity.Data.Entities;

namespace Identity.Data.Repositories
{
    public interface IRoleRepository : IAsyncRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string roleName);
    }
}