using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Data.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);

            builder.HasMany(p => p.RoleToPermissions)
                   .WithOne(rtp => rtp.Permission)
                   .HasForeignKey(rtp => rtp.PermissionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}