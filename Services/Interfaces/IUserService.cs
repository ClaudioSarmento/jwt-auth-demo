using JwtApi.Model;

namespace JwtApi.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        User? GetByUserName(string userName);
    }
}
