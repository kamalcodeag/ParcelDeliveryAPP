namespace Gateway.API.DTOs.ParcelDelivery
{
    public class GetParcelsByAuthorIdResponse
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Destination { get; set; }
        public string? AuthorId { get; set; }
        public string? AssigneeId { get; set; }
    }
}
