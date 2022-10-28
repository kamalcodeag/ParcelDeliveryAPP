using Identity.Data.Common;

namespace Identity.Data.Entities
{
    public class RoleToPermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public Guid PermissionId { get; set; }
        public virtual Permission? Permission { get; set; }
    }
}