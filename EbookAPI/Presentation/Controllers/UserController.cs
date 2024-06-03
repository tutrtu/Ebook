using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BusinessLogic.DTOs;

namespace EbookAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserByEmailAndPassword")]
        public async Task<IActionResult> GetUserByEmailAndPassword(string email, string password)
        {
            var user = await _userService.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto newUser)
        {
            if (newUser == null)
                return BadRequest(new { message = "User data is missing" });

            var registeredUser = await _userService.RegisterUserAsync(newUser);
            if (registeredUser == null)
                return BadRequest(new { message = "User with the same email already exists" });

            return CreatedAtAction(nameof(GetUserByEmailAndPassword), new { email = newUser.EmailAddress, password = newUser.Password }, registeredUser);
        }

    }
}
