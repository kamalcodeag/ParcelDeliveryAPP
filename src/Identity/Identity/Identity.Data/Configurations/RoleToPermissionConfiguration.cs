using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Data.Configurations
{
    internal class RoleToPermissionConfiguration : IEntityTypeConfiguration<RoleToPermission>
    {
        public void Configure(EntityTypeBuilder<RoleToPermission> builder)
        {
            builder.HasKey(rtp => rtp.Id);

            builder.HasOne(rtp => rtp.Role)
                   .WithMany(r => r.RoleToPermissions)
                   .HasForeignKey(rtp => rtp.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rtp => rtp.Permission)
                   .WithMany(p => p.RoleToPermissions)
                   .HasForeignKey(rtp => rtp.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}