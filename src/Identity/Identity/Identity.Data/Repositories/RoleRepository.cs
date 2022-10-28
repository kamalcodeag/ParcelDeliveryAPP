using Identity.Data.Contexts;
using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IdentityDbContext dbContext) : base(dbContext) {}

        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _dbContext.Roles.Where(x => x.Name.ToLower() == roleName.ToLower()).FirstOrDefaultAsync();
        }
    }
}