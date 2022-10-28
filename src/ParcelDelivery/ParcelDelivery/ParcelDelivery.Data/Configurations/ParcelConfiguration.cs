using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParcelDelivery.Data.Entities;

namespace ParcelDelivery.Data.Configurations
{
    internal class ParcelConfiguration : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Status).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Destination).IsRequired().HasMaxLength(255);
            builder.Property(p => p.AuthorId).IsRequired();
        }
    }
}