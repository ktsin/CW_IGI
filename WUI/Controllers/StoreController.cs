using System.Runtime.CompilerServices;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace WUI.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreService _storeService = null;
        
        public StoreController(StoreService storeService)
        {
            _storeService = storeService;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(StoreDTO _store)
        {
            return null;
        }
    }
}