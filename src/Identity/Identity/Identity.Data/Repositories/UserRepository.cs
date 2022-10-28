using Identity.Data.Contexts;
using Identity.Data.Entities;
using Identity.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IdentityDbContext dbContext) : base(dbContext) {}

        public async Task<IReadOnlyList<User>> GetAllCourierUsersAsync()
        {
            var data = await (from u in _dbContext.Users
                             join utr in _dbContext.UserToRoles on u.Id equals utr.UserId
                             join r in _dbContext.Roles on utr.RoleId equals r.Id
                             where r.Name == "courier"
                             select new User
                             {
                                 Id = u.Id,
                                 Name = u.Name,
                                 Surname = u.Surname,
                                 PhoneNumber = u.PhoneNumber,
                                 Address = u.Address,
                                 Email = u.Email,
                                 Username = u.Username
                             }).ToListAsync();
            
            return data;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<IReadOnlyList<UserRolePermissionsModel>> GetUserWithRolePermissionsAsync(string username)
        {
            var data = await (from u in _dbContext.Users
                              join utr in _dbContext.UserToRoles on u.Id equals utr.UserId into utr2
                              from utr3 in utr2.DefaultIfEmpty()
                              join r in _dbContext.Roles on utr3.RoleId equals r.Id into r2
                              from r3 in r2.DefaultIfEmpty()
                              join rtp in _dbContext.RoleToPermissions on r3.Id equals rtp.RoleId into rtp2
                              from rtp3 in rtp2.DefaultIfEmpty()
                              join p in _dbContext.Permissions on rtp3.PermissionId equals p.Id into p2
                              from p3 in p2.DefaultIfEmpty()
                              where u.Username == username
                              select new UserRolePermissionsModel
                              {
                                  Id = u.Id,
                                  Name = u.Name,
                                  Surname = u.Surname,
                                  PhoneNumber = u.PhoneNumber,
                                  Address = u.Address,
                                  Email = u.Email,
                                  Username = u.Username,
                                  Salt = u.Salt,
                                  PasswordHash = u.PasswordHash,
                                  RoleName = r3.Name,
                                  PermissionName = p3.Name
                              }).ToListAsync();

            return data;
        }
    }
}