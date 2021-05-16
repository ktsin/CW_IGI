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
    public class UsersController : Controller
    {
        private readonly MessageService _messageService;
        private readonly UserService _userService;
        private readonly UserManager<WebUser> _userManager;

        public UsersController(MessageService messageService,
            UserService userService,
            UserManager<WebUser> userManager)
        {
            _messageService = messageService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Messages()
        {
            if (User.Identity is {IsAuthenticated: true})
            {
                return View( _messageService.GetAllRecipientsForUser(1213));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Messages(int secondUserId)
        {
            if (User.Identity is {IsAuthenticated: true})
            {
                return View( _messageService.GetAllRecipientsForUser(1213));
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
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

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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