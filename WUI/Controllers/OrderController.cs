using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WUI.Auth;
using OrderDTO = BLL.DTO.OrderDTO;

namespace WUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly UserService _userService;
        private readonly GoodsService _goodsService;
        private readonly UserManager<WebUser> _userManager;
        private readonly ILogger<OrderController> _logger;
        
        public OrderController(OrderService orderService,
            UserService userService,
            GoodsService goodsService,
            UserManager<WebUser> userManager,
            ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _userService = userService;
            _goodsService = goodsService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var o = new OrderDTO();
            o.UserId = _userManager.Users.FirstOrDefault(e => e.UserName.Equals(User.Identity.Name))?.UnderlyingUserId??0;
            o.Goods = _userService.GetBasketByUser(o.UserId)?.SelectedGoods;
            ViewBag.Order = o;
            return View(o);
        }

        [HttpPost]
        public IActionResult Checkout(IFormCollection fields)
        {
            var o = new OrderDTO();
            o.UserId = _userManager.Users.FirstOrDefault(e => e.UserName.Equals(User.Identity.Name))?.UnderlyingUserId??0;
            o.Goods = _userService.GetBasketByUser(o.UserId)?.SelectedGoods;
            o.Notes = $"Email:{fields["Email"]}, address : {fields["Address"]}, Name : {fields["Name"]}";
            var basket = _userService.GetBasketByUser(o.UserId);
            _userService.CleanBasketByUserId(o.UserId);
            
            _orderService.PlaceOrder(o);
            return new ContentResult(){ Content = "Order placed"};
        }


        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Orders history
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            //get current user id 
            var userName = User.Identity?.Name;
            var user = _userManager.Users.FirstOrDefault(e => e.UserName == userName);
            var uid = user?.UnderlyingUserId ?? -1;
            if (uid < 0)
            {
                return NotFound();
            }
            return View(_orderService.GetOrderHistory(uid));
        }
    }
}