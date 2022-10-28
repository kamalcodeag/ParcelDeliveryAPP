using Identity.Data.Common;

namespace Identity.Data.Entities
{
    public class Permission : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<RoleToPermission>? RoleToPermissions { get; set; }
    }
}