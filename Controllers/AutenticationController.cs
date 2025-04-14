using JwtApi.Dtos;
using JwtApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class AutenticationController : Controller
    {
        private readonly ITokenService _tokenService;

        public AutenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Login(LoginDto loginDto)
        {

            var token = _tokenService.GenerateToken(loginDto);
            if(token == "") return Unauthorized();
            return Ok(token);
        }
    }
}

