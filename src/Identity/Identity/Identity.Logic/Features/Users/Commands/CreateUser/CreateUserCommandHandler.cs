using AutoMapper;
using Identity.Data.Entities;
using Identity.Data.Repositories;
using Identity.Logic.Utilities;
using MediatR;

namespace Identity.Logic.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserToRoleRepository _userToRoleRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository,
                                        IUserToRoleRepository userToRoleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userToRoleRepository = userToRoleRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserCommandResponse response = new CreateUserCommandResponse();

            CreateUserCommandValidator validator = new CreateUserCommandValidator();
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
                string salt = Guid.NewGuid().ToString();
                string passwordHash = HashUtility.CreatePasswordHash(request.ConfirmPassword, salt);

                var mappedUser = _mapper.Map<User>(request);
                mappedUser.Salt = salt;
                mappedUser.PasswordHash = passwordHash;

                var newUser = await _userRepository.AddAsync(mappedUser);

                var userRole = new Role();

                if (request.IsCourier)
                {
                    userRole = await _roleRepository.GetRoleByNameAsync("courier");
                }
                else
                {
                    userRole = await _roleRepository.GetRoleByNameAsync("user");
                }

                var newUserToRole = new UserToRole
                {
                    UserId = newUser.Id,
                    RoleId = userRole.Id
                };

                await _userToRoleRepository.AddAsync(newUserToRole);

                response = _mapper.Map<CreateUserCommandResponse>(newUser);
            }

            return response;
        }
    }
}