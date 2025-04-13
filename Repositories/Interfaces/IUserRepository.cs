using JwtApi.Model;

namespace JwtApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        User? GetByUserName(string userName);
    }
}
