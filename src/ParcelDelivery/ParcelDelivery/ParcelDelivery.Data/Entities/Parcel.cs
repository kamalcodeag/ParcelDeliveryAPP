using ParcelDelivery.Data.Common;

namespace ParcelDelivery.Data.Entities
{
    public class Parcel : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Destination { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? AssigneeId { get; set; }
    }
}