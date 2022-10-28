using MediatR;

namespace Identity.Logic.Features.Users.Queries.GetCourierUsers
{
    public class GetCourierUsersQuery : IRequest<List<GetCourierUsersQueryResponse>>
    {
    }
}