using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WUI.Models;
using System.Threading;

namespace WUI.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public AdminPanelController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            return await Task.Run(()=>View());
        }
        
        // public async Task<IActionResult> Index0()
        // {
        //     Thread.Sleep(1500);
        //     return await Task.Run(()=>PartialView("Index0"));
        // }

        // public IActionResult Privacy()
        // {
        //     return PartialView("Privacy");
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}