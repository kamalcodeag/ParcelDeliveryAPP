using Identity.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
            builder.Property(u => u.Surname).HasMaxLength(255);
            builder.Property(u => u.PhoneNumber).HasMaxLength(50);
            builder.Property(u => u.Address).HasMaxLength(255);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Salt).IsRequired().HasMaxLength(2500);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(2500);

            builder.HasMany(u => u.UserToRoles)
                   .WithOne(utr => utr.User)
                   .HasForeignKey(utr => utr.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}