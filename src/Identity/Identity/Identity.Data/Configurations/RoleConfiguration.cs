using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(255);
            builder.Property(r => r.Description).HasMaxLength(255);

            builder.HasMany(r => r.RoleToPermissions)
                   .WithOne(rtp => rtp.Role)
                   .HasForeignKey(rtp => rtp.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.UserToRoles)
                   .WithOne(utr => utr.Role)
                   .HasForeignKey(utr => utr.RoleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}