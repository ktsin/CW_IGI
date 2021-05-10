using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WUI.Auth;

namespace WUI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<AdminPanelController> _logger;
        private readonly WebUserContext _context = null;
        private readonly UserManager<WebUser> _userManager = null;
        private readonly RoleManager<WebUserRole> _roleManager = null;
        private readonly StoreService _stores = null;
        private readonly UserService _uUsers = null;

        public AdminPanelController(ILogger<AdminPanelController> logger,
            WebUserContext context,
            UserManager<WebUser> userManager,
            RoleManager<WebUserRole> roleManager,
            StoreService stores,
            UserService uUsers)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _stores = stores;
            _uUsers = uUsers;
        }

        public async Task<IActionResult> Index()
        {
            _logger?.LogInformation(new EventId(12, "AdminPanelShow"), "Admin panel showed", new object[] { });
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> Users()
        {
            return await Task.Run(() => PartialView("List/_User_main", _context.Users));
        }

        public async Task<IActionResult> UnderlyingUsers()
        {
            return await Task.Run(() => PartialView("List/_underlying_user_main", _uUsers));
        }
    }
}