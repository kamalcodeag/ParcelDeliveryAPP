using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAssigneeId
{
    public class GetParcelsByAssigneeIdQueryHandler : IRequestHandler<GetParcelsByAssigneeIdQuery, List<GetParcelsByAssigneeIdQueryResponse>>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public GetParcelsByAssigneeIdQueryHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetParcelsByAssigneeIdQueryResponse>> Handle(GetParcelsByAssigneeIdQuery request, CancellationToken cancellationToken)
        {
            var response = new List<GetParcelsByAssigneeIdQueryResponse>();

            GetParcelsByAssigneeIdQueryValidator validator = new GetParcelsByAssigneeIdQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                var responseItem = new GetParcelsByAssigneeIdQueryResponse();
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
                var allParcelsByAssigneeId = await _parcelRepository.GetParcelsByAssigneeIdAsync(request.AssigneeId);
                response = _mapper.Map<List<GetParcelsByAssigneeIdQueryResponse>>(allParcelsByAssigneeId);
            }

            return response;
        }
    }
}
