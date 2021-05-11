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
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                UserDTO uUser = new UserDTO()
                {
                    Birtday = model.Birtday, Address = model.Address, Name = model.Name,
                    RegistrationDay = DateTime.Now.ToShortDateString()
                };
                
                WebUser user = new WebUser { Email = model.Email, UserName = model.Email,};
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
    }
}