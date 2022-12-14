using Identity.Logic.Responses;

namespace Identity.Logic.Features.Users.Queries.GetCourierUsers
{
    public class GetCourierUsersQueryResponse : BaseResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
    }
}