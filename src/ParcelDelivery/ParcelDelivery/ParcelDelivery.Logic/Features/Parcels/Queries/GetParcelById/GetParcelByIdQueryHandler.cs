using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelById
{
    public class GetParcelByIdQueryHandler : IRequestHandler<GetParcelByIdQuery, GetParcelByIdQueryResponse>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public GetParcelByIdQueryHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<GetParcelByIdQueryResponse> Handle(GetParcelByIdQuery request, CancellationToken cancellationToken)
        {
            GetParcelByIdQueryResponse response = new GetParcelByIdQueryResponse();

            GetParcelByIdQueryValidator validator = new GetParcelByIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            var parcelFromDb = await _parcelRepository.GetByIdAsync(Guid.Parse(request.Id));

            if (parcelFromDb == null)
            {
                response.Success = false;
                response.Message = "The parcel couldn't be found";
                return response;
            }

            if (response.Success)
            {
                response = _mapper.Map<GetParcelByIdQueryResponse>(parcelFromDb);
            }

            return response;
        }
    }
}
