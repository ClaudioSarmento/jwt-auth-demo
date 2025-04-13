using JwtApi.Model;
using JwtApi.Repositories.Interfaces;
using JwtApi.Services.Interfaces;

namespace JwtApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        public void Add(User user)
        {
            _userRepository.Add(user);
        }

        public User? GetByUserName(string userName)
        {
            return _userRepository.GetByUserName(userName);
        }
    }
}
