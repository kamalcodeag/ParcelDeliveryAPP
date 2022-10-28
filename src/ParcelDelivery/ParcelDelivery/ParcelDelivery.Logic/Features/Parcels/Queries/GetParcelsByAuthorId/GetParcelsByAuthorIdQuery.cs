using MediatR;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAuthorId
{
    public class GetParcelsByAuthorIdQuery : IRequest<List<GetParcelsByAuthorIdQueryResponse>>
    {
        public string? AuthorId { get; set; }
    }
}
