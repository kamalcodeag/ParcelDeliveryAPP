using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Entities;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel
{
    public class CreateParcelCommandHandler : IRequestHandler<CreateParcelCommand, CreateParcelCommandResponse>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public CreateParcelCommandHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<CreateParcelCommandResponse> Handle(CreateParcelCommand request, CancellationToken cancellationToken)
        {
            CreateParcelCommandResponse response = new CreateParcelCommandResponse();

            CreateParcelCommandValidator validator = new CreateParcelCommandValidator();
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

            if (response.Success)
            {
                var mappedParcel = _mapper.Map<Parcel>(request);
                mappedParcel.Status = "Not purchased yet";
                mappedParcel.Destination = "Unknown";

                var newParcel = await _parcelRepository.AddAsync(mappedParcel);

                response = _mapper.Map<CreateParcelCommandResponse>(newParcel);
            }

            return response;
        }
    }
}