using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WUI.Models;
using System.Threading;
using BLL.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace WUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GoodsService _goodsService;

        public HomeController(ILogger<HomeController> logger,
            GoodsService goodsService)
        {
            _logger = logger;
            _goodsService = goodsService;
        }

        [HttpGet]
        public async Task<IActionResult> Cards()
        {
            return await Task.Run(() => PartialView("_ProductCards", _goodsService.GetAllGoods()));
        }
        
        [HttpGet]
        public async Task<IActionResult> CardsByCategory(int id)
        {
            
            return await Task.Run(() => PartialView("_ProductCards", _goodsService.GetGoodsByCategoryId(id)));
        }
        
        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            return await Task.Run(() => PartialView("_Categories", _goodsService.GetCategories()));
        }
        
        public IActionResult Index()
        {
            return View("_Products");
        }

        public async Task<IActionResult> Index0()
        {
            Thread.Sleep(1500);
            return await Task.Run(() => PartialView("Index0"));
        }

        public IActionResult Privacy()
        {
            return PartialView("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult ChangeLanguage(string code)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(code)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return RedirectToAction("Index");
        }
    }
}