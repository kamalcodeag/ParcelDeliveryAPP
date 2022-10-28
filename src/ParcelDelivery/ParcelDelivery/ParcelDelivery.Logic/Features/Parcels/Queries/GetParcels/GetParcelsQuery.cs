using MediatR;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcels
{
    public class GetParcelsQuery : IRequest<List<GetParcelsQueryResponse>>
    {
    }
}
