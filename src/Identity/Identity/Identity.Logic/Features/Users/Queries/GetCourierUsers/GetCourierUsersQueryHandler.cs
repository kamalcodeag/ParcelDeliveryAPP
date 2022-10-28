using AutoMapper;
using Identity.Data.Repositories;
using MediatR;

namespace Identity.Logic.Features.Users.Queries.GetCourierUsers
{
    public class GetCourierUsersQueryHandler : IRequestHandler<GetCourierUsersQuery, List<GetCourierUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetCourierUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCourierUsersQueryResponse>> Handle(GetCourierUsersQuery request, CancellationToken cancellationToken)
        {
            var allCourierUsers = await _userRepository.GetAllCourierUsersAsync();
            return _mapper.Map<List<GetCourierUsersQueryResponse>>(allCourierUsers);
        }
    }
}