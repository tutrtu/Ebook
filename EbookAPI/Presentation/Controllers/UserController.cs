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
    }
}
