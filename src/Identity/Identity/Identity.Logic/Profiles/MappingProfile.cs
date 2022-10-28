using AutoMapper;
using Identity.Data.Entities;
using Identity.Logic.Features.Users.Commands.CreateUser;
using Identity.Logic.Features.Users.Queries.GetCourierUsers;

namespace Identity.Logic.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<User, CreateUserCommandResponse>().ReverseMap();
            CreateMap<User, GetCourierUsersQueryResponse>().ReverseMap();
        }
    }
}