using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WUI.Models;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WUI.Auth;

namespace WUI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebUserContext _context = null;
        private readonly UserManager<WebUser> _userManager = null;

        public AdminPanelController(ILogger<HomeController> logger,
            WebUserContext context,
            UserManager<WebUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            _logger?.LogInformation(new EventId(12, "AdminPanelShow"), "Admin panel showed", new object[]{} );
            return await Task.Run(()=>View());
        }

        public async Task<IActionResult> Users()
        {
            return await Task.Run(() => View(_context.Users.ToList()));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
        
        public async Task<IActionResult> CreateUser()
        {
            return await Task.Run(() => PartialView(new WebUser()));
        }

        [HttpPost]
        public async Task<IActionResult> OnCreateUserForm(WebUser user)
        {
            WebUser n_user = new WebUser() { Email = user.Email, UserName = user.UserName, UnderlyingUserId = user.UnderlyingUserId};
            // добавляем пользователя
            var result = await _userManager.CreateAsync(n_user, user.PasswordHash);
            if (result.Succeeded)
            {
                
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return RedirectToAction("Users");
        }
    }
}