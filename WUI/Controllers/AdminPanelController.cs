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
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly StoreService _storeService;

        public AdminPanelController(ILogger<AdminPanelController> logger,
            WebUserContext context,
            UserManager<WebUser> userManager,
            RoleManager<IdentityRole> roleManager,
            StoreService stores,
            UserService uUsers,
            GoodsService goodsService,
            OrderService orderService,
            StoreService storeService)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _stores = stores;
            _uUsers = uUsers;
            _goodsService = goodsService;
            _orderService = orderService;
            _storeService = storeService;
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
                            _stores.GetAllManagers()));
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return await Task.Run(() => PartialView("Forms/Add/_AddCategoryModal",
                new CategoryDTO()));
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO category)
        {
            bool res = _goodsService.AddCategory(category);
            var response = new ContentResult();
            if (res)
            {
                response.Content = "successfully added";
            }
            else
            {
                response.Content = "Exception occured. Try again";
            }

            return response;
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _goodsService.DeleteCategory(id);
            }
            catch
            {
                
            }
            return RedirectToAction("Index");
        }
        
        // public IActionResult DeleteUser(string id)
        // {
        //     try
        //     {
        //         
        //     }
        //     catch
        //     {
        //         
        //     }
        //     return RedirectToAction("Index");
        // }

        [HttpGet]
        public IActionResult AddStore()
        {
            ViewBag.OwnerId = _uUsers.GetUsers().Select(e=>new SelectListItem(e.Name, e.Id.ToString())).ToList();
            return PartialView("Forms/Add/_AddStoreModal", new BLL.DTO.StoreDTO());
        }

        [HttpPost]
        public IActionResult AddStore(StoreDTO store)
        {
            if (_storeService.RegisterStore(store))
                return new ContentResult() { Content = "Succesfully added!" };
            else
                return new ContentResult() { Content = "Exception occured!" };
        }

        [HttpGet]
        public IActionResult AddManager()
        {

            ViewBag.UserId = _uUsers.GetUsers().Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();
            ViewBag.StoreId = _storeService.GetAllStores().Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();
            return PartialView("Forms/Add/_AddManagerToStore", new BLL.DTO.ManagersDTO());
        }

        [HttpPost]
        public IActionResult AddManager(ManagersDTO manager)
        {
            if (_stores.AssignManager(manager))
                return new ContentResult() { Content = "Succesfully added!" };
            else
                return new ContentResult() { Content = "Exception occured!" };
        }

        [HttpGet]
        public IActionResult AddGood()
        {
            ViewBag.CategoryId = _goodsService.GetCategories().Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();
            ViewBag.StoreId = _storeService.GetAllStores().Select(e => new SelectListItem(e.Name, e.Id.ToString())).ToList();
            return PartialView("Forms/Add/_AddGoodModal", new BLL.DTO.GoodDTO());
        }

        [HttpPost]
        public IActionResult AddGood(GoodDTO good)
        {
            if (_goodsService.AddGood(good))
                return new ContentResult() { Content = "Succesfully added!" };
            else
                return new ContentResult() { Content = "Exception occured!" };
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return PartialView("Forms/Add/_AddUserModal", new WUI.Auth.WebUser());
        }

        [HttpPost]
        public IActionResult AddUser(Auth.WebUser user)
        {
            var ir = _userManager.CreateAsync(user).Result;
            if (ir.Succeeded)
            {
                _userManager.AddPasswordAsync(user, user.PasswordHash);
                return new ContentResult() { Content = "Succesfully added!" };
            }
            else
                return new ContentResult() { Content = "Exception occured!" };               
        }

        public IActionResult DeleteStore(int id)
        {
            try
            {
                _stores.DeleteStore(id);
            }
            catch
            {
                
            }

            return RedirectToAction("Index");
        }
    }
}