using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WUI.Models;
using Microsoft.AspNetCore.Identity;
using WUI.Auth;

namespace WUI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebUserContext _context = null;
        private readonly UserManager<WebUser> _userManager = null;
        private readonly RoleManager<WebUserRole> _roleManager = null;
        private readonly StoreService _stores = null;

        public AdminPanelController(ILogger<HomeController> logger,
            WebUserContext context,
            UserManager<WebUser> userManager,
            RoleManager<WebUserRole> roleManager,
            StoreService stores)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _stores = stores;
        }
        
        public async Task<IActionResult> Index()
        {
            _logger?.LogInformation(new EventId(12, "AdminPanelShow"), "Admin panel showed", new object[]{} );
            return await Task.Run(()=>View());
        }

        public async Task<IActionResult> Users()
        {
            return await Task.Run(() => View(_context));
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
            WebUser n_user = new WebUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                UnderlyingUserId = user.UnderlyingUserId,
                EmailConfirmed = user.EmailConfirmed,
                AccessFailedCount = user.AccessFailedCount,
                PhoneNumber = user.PhoneNumber,
            };
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

        public async Task<IActionResult> OnCreateRole(WebUserRole role)
        {
            if (_context.Roles.Any(e => ((e.Id.CompareTo(role.Id)) == 0)))
            {
                await _roleManager.SetRoleNameAsync(role, role.Name);
            }
            else
            {
                role.Id = null;
                await _roleManager.CreateAsync(role);
            }
            return RedirectToAction("Users", _context);
        }

        [HttpGet]
        public async Task<IActionResult> Stores()
        {
            return null;
        }

        [HttpGet]
        public IActionResult _addStore()
        {
            var tmp = new StoreDTO();
            return View("_StoresAddForm", tmp);
        }
    }
}