using AutoMapper;
using MediatR;
using ParcelDelivery.Data.Entities;
using ParcelDelivery.Data.Repositories;

namespace ParcelDelivery.Logic.Features.Parcels.Commands.UpdateParcel
{
    public class UpdateParcelCommandHandler : IRequestHandler<UpdateParcelCommand, UpdateParcelCommandResponse>
    {
        private readonly IParcelRepository _parcelRepository;
        private readonly IMapper _mapper;

        public UpdateParcelCommandHandler(IParcelRepository parcelRepository, IMapper mapper)
        {
            _parcelRepository = parcelRepository;
            _mapper = mapper;
        }

        public async Task<UpdateParcelCommandResponse> Handle(UpdateParcelCommand request, CancellationToken cancellationToken)
        {
            UpdateParcelCommandResponse response = new UpdateParcelCommandResponse();

            var parcelFromDb = await _parcelRepository.GetByIdAsync(Guid.Parse(request.Id));

            if(parcelFromDb == null)
            {
                response.Success = false;
                response.Message = "The parcel couldn't be found";
                return response;
            }

            _mapper.Map(request, parcelFromDb, typeof(UpdateParcelCommand), typeof(Parcel));
            await _parcelRepository.UpdateAsync(parcelFromDb);

            response = _mapper.Map<UpdateParcelCommandResponse>(parcelFromDb);

            return response;
        }
    }
}
