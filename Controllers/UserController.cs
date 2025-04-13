using JwtApi.Model;
using JwtApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add-user",Name = "add-user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AddUser(User user)
        {
            _userService.Add(user);
            return Ok("User Inserted successfully!");
        }
    }
}
