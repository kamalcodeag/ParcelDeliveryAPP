using MediatR;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelById
{
    public class GetParcelByIdQuery : IRequest<GetParcelByIdQueryResponse>
    {
        public string? Id { get; set; }
    }
}
