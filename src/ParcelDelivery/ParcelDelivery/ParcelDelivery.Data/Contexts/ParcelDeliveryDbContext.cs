using Microsoft.EntityFrameworkCore;
using ParcelDelivery.Data.Common;
using ParcelDelivery.Data.Entities;
using System.Reflection;

namespace ParcelDelivery.Data.Contexts
{
    public class ParcelDeliveryDbContext: DbContext
    {
        public ParcelDeliveryDbContext(DbContextOptions<ParcelDeliveryDbContext> options) : base(options) { }

        public DbSet<Parcel>? Parcels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}