using Microsoft.EntityFrameworkCore;
using ParcelDelivery.Data.Contexts;
using ParcelDelivery.Data.Entities;

namespace ParcelDelivery.Data.Repositories
{
    public class ParcelRepository : BaseRepository<Parcel>, IParcelRepository
    {
        public ParcelRepository(ParcelDeliveryDbContext dbContext) : base(dbContext) {}

        public async Task<IReadOnlyList<Parcel>> GetParcelsByAuthorIdAsync(string authorId)
        {
            return await _dbContext.Parcels.Where(x => x.AuthorId == Guid.Parse(authorId)).ToListAsync();
        }

        public async Task<IReadOnlyList<Parcel>> GetParcelsByAssigneeIdAsync(string assigneeId)
        {
            return await _dbContext.Parcels.Where(x => x.AssigneeId == Guid.Parse(assigneeId)).ToListAsync();
        }
    }
}