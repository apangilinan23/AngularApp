using Microsoft.AspNetCore.Mvc;
using AngularApp.Server.Models;
using AngularApp.Server.Services;

namespace AngularApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Login(string username)
        {
            var user = await _userService.LoginAsync(username);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(new UserViewModel { Username = username });
        }
    }
}
