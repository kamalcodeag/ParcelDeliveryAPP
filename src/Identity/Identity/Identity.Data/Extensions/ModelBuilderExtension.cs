using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Permission
            Permission canChangeStatusOfParcel = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanChangeTheStatusOfParcelDeliveryOrder"
            };

            Permission canViewAllParcels = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanViewAllParcelDeliveryOrders"
            };

            Permission canAssignParcelToCourier = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanAssignParcelDeliveryOrderToCourier"
            };

            Permission canLogInCreateCourierAccount = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanLogInCreateCourierAccount"
            };

            Permission canTrackDeliveryByCoordinates = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanTrackTheDeliveryOrderByCoordinates"
            };

            Permission canSeeListOfCouriers = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "CanSeeListOfCouriers"
            };

            modelBuilder.Entity<Permission>().HasData(canChangeStatusOfParcel, canViewAllParcels, canAssignParcelToCourier, canLogInCreateCourierAccount,
                                                      canTrackDeliveryByCoordinates, canSeeListOfCouriers);
            #endregion

            #region Role
            Role adminRole = new Role
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "admin",
                Description = "admin"
            };

            Role userRole = new Role
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "user",
                Description = "user"
            };

            Role courierRole = new Role
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "courier",
                Description = "courier"
            };

            modelBuilder.Entity<Role>().HasData(adminRole, userRole, courierRole);
            #endregion

            #region RoleToPermission
            RoleToPermission adminCanChangeStatusParcelRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canChangeStatusOfParcel.Id
            };

            RoleToPermission adminCanViewAllParcelsRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canViewAllParcels.Id
            };

            RoleToPermission adminCanAssignParcelToCourierRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canAssignParcelToCourier.Id
            };

            RoleToPermission adminCanLogInCreateCourierAccountRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canLogInCreateCourierAccount.Id
            };

            RoleToPermission adminCanTrackDeliveryByCoordinatesRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canTrackDeliveryByCoordinates.Id
            };

            RoleToPermission adminCanSeeListOfCouriersRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = canSeeListOfCouriers.Id
            };

            modelBuilder.Entity<RoleToPermission>().HasData(adminCanChangeStatusParcelRoleToPermission, adminCanViewAllParcelsRoleToPermission,
                                                            adminCanAssignParcelToCourierRoleToPermission, adminCanLogInCreateCourierAccountRoleToPermission,
                                                            adminCanTrackDeliveryByCoordinatesRoleToPermission, adminCanSeeListOfCouriersRoleToPermission);
            #endregion

            #region User
            string adminSalt = Guid.NewGuid().ToString();
            string adminPassword = "Admin1234@";

            User adminUser = new User
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = "admin",
                Surname = "admin",
                PhoneNumber = string.Empty,
                Address = string.Empty,
                Email = "admin@admin.com",
                Username = "admin",
                Salt = adminSalt,
                PasswordHash = CreatePasswordHash(adminPassword, adminSalt)
            };

            modelBuilder.Entity<User>().HasData(adminUser);
            #endregion

            #region UserToRole
            UserToRole adminUserToRole = new UserToRole
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };

            modelBuilder.Entity<UserToRole>().HasData(adminUserToRole);
            #endregion
        }

        private static string CreatePasswordHash(string password, string salt)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (salt == null)
            {
                throw new ArgumentNullException(nameof(salt));
            }

            StringBuilder hash = new StringBuilder();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(salt);

            using (var hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(passwordBytes);

                foreach (var value in hashValue)
                {
                    hash.Append(value.ToString("x2"));
                }
            }

            return hash.ToString();
        }
    }
}