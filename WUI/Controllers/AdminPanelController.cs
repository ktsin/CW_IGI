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
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;
using WUI.Auth;
using OrderState = DAL.Entities.OrderState;

namespace WUI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<AdminPanelController> _logger;
        private readonly WebUserContext _context = null;
        private readonly UserManager<WebUser> _userManager = null;
        private readonly RoleManager<IdentityRole> _roleManager = null;
        private readonly StoreService _stores = null;
        private readonly UserService _uUsers = null;
        private readonly GoodsService _goodsService = null;
        private readonly OrderService _orderService = null;

        public AdminPanelController(ILogger<AdminPanelController> logger,
            WebUserContext context,
            UserManager<WebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            StoreService stores,
            UserService uUsers,
            GoodsService goodsService,
            OrderService orderService
            )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _stores = stores;
            _uUsers = uUsers;
            _goodsService = goodsService;
            _orderService = orderService;
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
            //TODO: add logic
            return await Task.Run(() => PartialView("List/_underlying_user_main",
                null));
        }

        public async Task<IActionResult> Categories()
        {
            return await Task.Run(() => PartialView("List/_Categories_main",
                _goodsService.GetCategories()));
        }

        public async Task<IActionResult> Goods()
        {
            return await Task.Run(() => PartialView("List/_Goods_main",
                _goodsService.GetAllGoods()));
        }
        
        public async Task<IActionResult> Roles()
        {
            return await Task.Run(() => PartialView("List/_Roles_main",
                _roleManager.Roles));
        }
        
        public async Task<IActionResult> Stores()
        {
            return await Task.Run(() => PartialView("List/_Stores_main",
                _stores.GetAllStores()));
        }
        
        public async Task<IActionResult> Orders()
        {
            return await Task.Run(() => PartialView("List/_Orders_main",
                _orderService.GetAll()));
        }

        public async Task<IActionResult> Managers()
        {
            return await Task.Run(() => PartialView("List/_Managers_main",
                            _orderService.GetAll()));
        }

        public IActionResult AddUser()
        {
            
            throw new System.NotImplementedException();
        }
    }
}