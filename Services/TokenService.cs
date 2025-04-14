using JwtApi.Dtos;
using JwtApi.Model;
using JwtApi.Repositories.Interfaces;
using JwtApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtApi.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public TokenService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public string GenerateToken(LoginDto loginDto)
        {
            var userDatabase = _userRepository.GetByUserName(loginDto.UserName);
            if( userDatabase == null || loginDto.UserName != userDatabase.UserName || loginDto.Password != userDatabase.Password)
                return string.Empty;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, userDatabase.UserName),
                    new Claim(type: ClaimTypes.Role, userDatabase.Role)
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        
        }
    }
}
