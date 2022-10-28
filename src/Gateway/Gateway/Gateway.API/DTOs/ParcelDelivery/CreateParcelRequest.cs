namespace Gateway.API.DTOs.ParcelDelivery
{
    public class CreateParcelRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AuthorId { get; set; }
        public string? AssigneeId { get; set; }
    }
}
