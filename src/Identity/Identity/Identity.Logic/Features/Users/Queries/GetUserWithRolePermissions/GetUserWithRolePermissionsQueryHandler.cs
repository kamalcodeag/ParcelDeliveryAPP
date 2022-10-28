using AutoMapper;
using Identity.Data.Repositories;
using Identity.Logic.Services;
using Identity.Logic.Utilities;
using MediatR;

namespace Identity.Logic.Features.Users.Queries.GetUserWithRolePermissions
{
    public class GetUserWithRolePermissionsQueryHandler : IRequestHandler<GetUserWithRolePermissionsQuery, GetUserWithRolePermissionsQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;
        private readonly IMapper _mapper;

        public GetUserWithRolePermissionsQueryHandler(IUserRepository userRepository, IJWTService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<GetUserWithRolePermissionsQueryResponse> Handle(GetUserWithRolePermissionsQuery request, CancellationToken cancellationToken)
        {
            GetUserWithRolePermissionsQueryResponse response = new GetUserWithRolePermissionsQueryResponse();

            GetUserWithRolePermissionsQueryValidator validator = new GetUserWithRolePermissionsQueryValidator();
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

            var data = await _userRepository.GetUserWithRolePermissionsAsync(request.Username);

            if (data.Count() == 0)
            {
                response.Success = false;
                response.Message = "User couldn't be found";
                return response;
            }

            if(!HashUtility.VerifyPasswordHash(request.Password, data.FirstOrDefault().Salt, data.FirstOrDefault().PasswordHash))
            {
                response.Success = false;
                response.Message = "Username or password is wrong";
                return response;
            }

            if (response.Success)
            {
                response.Token = _jwtService.GenerateToken(data);
            }

            return response;
        }
    }
}
