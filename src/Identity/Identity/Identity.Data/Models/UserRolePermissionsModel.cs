using Identity.Data.Entities;

namespace Identity.Data.Models
{
    public class UserRolePermissionsModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public string? RoleName { get; set; }
        public string? PermissionName { get; set; }
    }
}
