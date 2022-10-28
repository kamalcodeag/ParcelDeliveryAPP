using Identity.Data.Common;

namespace Identity.Data.Entities
{
    public class Role : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<RoleToPermission>? RoleToPermissions { get; set; }
        public virtual ICollection<UserToRole>? UserToRoles { get; set; }
    }
}