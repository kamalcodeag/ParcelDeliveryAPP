using System.Text.Json.Serialization;

namespace Gateway.API.DTOs.ParcelDelivery
{
    public class UpdateParcelRequest
    {
        [JsonIgnore]
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Destination { get; set; }
        public string? AssigneeId { get; set; }
    }
}
