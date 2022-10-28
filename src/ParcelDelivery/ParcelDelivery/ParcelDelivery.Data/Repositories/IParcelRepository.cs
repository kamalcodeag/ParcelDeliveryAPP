using ParcelDelivery.Data.Entities;

namespace ParcelDelivery.Data.Repositories
{
    public interface IParcelRepository : IAsyncRepository<Parcel>
    {
        Task<IReadOnlyList<Parcel>> GetParcelsByAuthorIdAsync(string authorId);
        Task<IReadOnlyList<Parcel>> GetParcelsByAssigneeIdAsync(string assigneeId);
    }
}