using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WUI.Auth;
using WUI.Models;

namespace WUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly SignInManager<WebUser> _signInManager;
        private readonly UserService _userService;

        public AccountController(
            UserManager<WebUser> userManager,
            SignInManager<WebUser> signInManager,
            UserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO uUser = new UserDTO
                {
                    Birtday = model.Birtday, Address = model.Address, Name = model.Name,
                    RegistrationDay = DateTime.Now.ToShortDateString()
                };
                uUser = _userService.AttachUser(uUser);

                WebUser user = new WebUser
                {
                    Email = model.Email,
                    UserName = model.Email.Replace('@', 'A').Replace('.', 'D'),
                    UnderlyingUserId = uUser.Id
                };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager
                    .PasswordSignInAsync(model.Email.Replace('@', 'A').Replace('.', 'D'), model.Password, model.RememberMe, lockoutOnFailure: false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return RedirectToAction("Login", model);
                }
            }
            return RedirectToAction("Login", model);
        }
    }
}