using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WUI.Auth;

namespace WUI.Controllers
{
    public class UserBasketController : Controller
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly UserService _userService;

        public UserBasketController(UserManager<WebUser> userManager, UserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }
        
        public IActionResult ShowBasket()
        {
            //get current user
            var webUserName = User.Identity.Name;
            var webUser = _userManager.Users.FirstOrDefault(e => e.UserName == webUserName);
            var id = webUser?.UnderlyingUserId??-1;
            if (id <= 0)
            {
                return NotFound();
            }

            var basket = _userService.GetBasketByUser(id);
            
            return View("Basket",basket);
        }
        // GET: UserBasket
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserBasket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserBasket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserBasket/Create
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

        // GET: UserBasket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserBasket/Edit/5
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

        // GET: UserBasket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserBasket/Delete/5
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
    }
}