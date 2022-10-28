using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcels
{
    public class GetParcelsQueryHandler : IRequestHandler<GetParcelsQuery, List<GetParcelsQueryResponse>>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public GetParcelsQueryHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetParcelsQueryResponse>> Handle(GetParcelsQuery request, CancellationToken cancellationToken)
        {
            var allParcels = await _parcelRepository.ListAllAsync();
            return _mapper.Map<List<GetParcelsQueryResponse>>(allParcels);
        }
    }
}
