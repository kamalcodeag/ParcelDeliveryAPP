using Identity.Logic.Responses;

namespace Identity.Logic.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}