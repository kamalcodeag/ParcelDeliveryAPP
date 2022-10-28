using MediatR;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAssigneeId
{
    public class GetParcelsByAssigneeIdQuery : IRequest<List<GetParcelsByAssigneeIdQueryResponse>>
    {
        public string? AssigneeId { get; set; }
    }
}
