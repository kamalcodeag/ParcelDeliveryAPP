using ParcelDelivery.Logic.Responses;

namespace ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel
{
    public class CreateParcelCommandResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}