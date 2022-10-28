using MediatR;

namespace ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel
{
    public class CreateParcelCommand : IRequest<CreateParcelCommandResponse>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? AuthorId { get; set; }
        public string? AssigneeId { get; set; }
    }
}