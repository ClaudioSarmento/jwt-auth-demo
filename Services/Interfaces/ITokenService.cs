using JwtApi.Dtos;
using JwtApi.Model;

namespace JwtApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(LoginDto loginDto);
    }
}
