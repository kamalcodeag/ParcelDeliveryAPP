using Identity.Data.Contexts;
using Identity.Data.Entities;

namespace Identity.Data.Repositories
{
    public class UserToRoleRepository : BaseRepository<UserToRole>, IUserToRoleRepository
    {
        public UserToRoleRepository(IdentityDbContext dbContext) : base(dbContext) { }
    }
}
