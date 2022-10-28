using AutoMapper;
using ParcelDelivery.Data.Entities;
using ParcelDelivery.Logic.Features.Parcels.Commands.CreateParcel;
using ParcelDelivery.Logic.Features.Parcels.Commands.UpdateParcel;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelById;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcels;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAssigneeId;
using ParcelDelivery.Logic.Features.Parcels.Queries.GetParcelsByAuthorId;

namespace ParcelDelivery.Logic.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateParcelCommand, Parcel>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => Guid.Parse(x.AuthorId)))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => Guid.Parse(x.AssigneeId)))
                .ReverseMap();
            CreateMap<Parcel, CreateParcelCommandResponse>().ReverseMap();

            CreateMap<UpdateParcelCommand, Parcel>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.AuthorId, opt => opt.Ignore())
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => Guid.Parse(x.AssigneeId)))
                .ReverseMap();
            CreateMap<Parcel, UpdateParcelCommandResponse>().ReverseMap();

            CreateMap<Parcel, GetParcelsQueryResponse>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId.ToString()))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => x.AssigneeId.ToString()))
                .ReverseMap();

            CreateMap<Parcel, GetParcelsByAssigneeIdQueryResponse>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId.ToString()))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => x.AssigneeId.ToString()))
                .ReverseMap();

            CreateMap<Parcel, GetParcelsByAuthorIdQueryResponse>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId.ToString()))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => x.AssigneeId.ToString()))
                .ReverseMap();

            CreateMap<Parcel, GetParcelByIdQueryResponse>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId.ToString()))
                .ForMember(x => x.AssigneeId, opt => opt.MapFrom(x => x.AssigneeId.ToString()))
                .ReverseMap();
        }
    }
}