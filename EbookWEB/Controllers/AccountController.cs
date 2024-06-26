﻿using EbookWEB.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EbookAPI.BussinessLogic;
using EbookWEB.Service;
using EbookAPI.BusinessLogic.DTOs;
using Newtonsoft.Json;

namespace EbookWEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _userService;

        public AccountController(AccountService userService)
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
                var user = await _userService.GetAccountByEmailAndPassword(model.Email, model.Password);
                if (user != null)
                {
                    string userJson = JsonConvert.SerializeObject(user);
                    HttpContext.Session.SetString("user", userJson);

                    return RedirectToAction("Index", "Author");
                }
                ModelState.AddModelError("", "Invalid email or password");
            }

            var combinedModel = new CombinedAuthViewModel
            {
                Login = model,
                Register = new RegisterViewModel()
            };
            return View(combinedModel);
        }

        // Other actions for registration, etc.
    }
}
