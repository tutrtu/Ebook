using EbookWEB.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EbookAPI.BussinessLogic;
using EbookAPI.BusinessLogic.Interfaces;
using EbookAPI.BusinessLogic.DTOs;


namespace EbookWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Auth()
        {
            var model = new CombinedAuthViewModel
            {
                Login = new LoginViewModel(),
                Register = new RegisterViewModel()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check credentials using UserService
                var user = await _userService.GetUserByEmailAndPasswordAsync(model.Email, model.Password);
                if (user != null)
                {
                    // Perform any additional authentication logic if needed
                    // For example, setting a session variable

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid email or password");
            }

            var combinedModel = new CombinedAuthViewModel
            {
                Login = model,
                Register = new RegisterViewModel()
            };
            return View("Auth", combinedModel);
        }

        

        // Other actions for registration, etc.
    }

}
