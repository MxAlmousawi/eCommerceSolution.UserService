using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<AuthenticationResponse> Login(LoginRequest request)
        {
            var user = await usersRepository.GetUserByEmailAndPassword(
                request.Email,
                request.Password
            );
            if (user == null)
                return null;

            return mapper.Map<AuthenticationResponse>(user) with
            {
                Success = true,
                Token = "token",
            };
        }

        public async Task<AuthenticationResponse> Register(RegisterRequest request)
        {
            var user = mapper.Map<ApplicationUser>(request);
            var registeredUser = await usersRepository.AddUser(user);
            if (registeredUser == null)
                return null;

            return mapper.Map<AuthenticationResponse>(registeredUser) with
            {
                Success = true,
                Token = "token",
            };
        }
    }
}
