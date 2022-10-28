using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAuthorId
{
    public class GetParcelsByAuthorIdQueryHandler : IRequestHandler<GetParcelsByAuthorIdQuery, List<GetParcelsByAuthorIdQueryResponse>>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public GetParcelsByAuthorIdQueryHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetParcelsByAuthorIdQueryResponse>> Handle(GetParcelsByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var response = new List<GetParcelsByAuthorIdQueryResponse>();

            GetParcelsByAuthorIdQueryValidator validator = new GetParcelsByAuthorIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                var responseItem = new GetParcelsByAuthorIdQueryResponse();
                responseItem.Success = false;
                responseItem.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    responseItem.ValidationErrors.Add(error.ErrorMessage);
                }

                response.Add(responseItem);
            }

            if (response.Count() == 0)
            {
                var allParcelsByAuthorId = await _parcelRepository.GetParcelsByAuthorIdAsync(request.AuthorId);
                response = _mapper.Map<List<GetParcelsByAuthorIdQueryResponse>>(allParcelsByAuthorId);
            }

            return response;
        }
    }
}
