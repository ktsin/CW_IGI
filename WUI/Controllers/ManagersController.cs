using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WUI.Models;

namespace WUI.Controllers
{
    public class ManagersController : Controller
    {
        private readonly OrderService _orderService;
        private readonly StoreService _storeService;

        public ManagersController(OrderService orderService, StoreService storeService)
        {
            _orderService = orderService;
            _storeService = storeService;
        }

        // GET: Managers
        public ActionResult Index()
        {
            var model = new ManagersViewModel();
            model.AssignedStores = _storeService.GetAllStores();
            model.OrdersToProcess = _orderService.GetAll();
            return View("ManagerPanel", model);
        }

        // GET: Managers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
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

        // GET: Managers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Managers/Edit/5
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

        // GET: Managers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Managers/Delete/5
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

        public IActionResult SaveOrderState(int orderId, OrderState orderState)
        {
            ContentResult res = new ContentResult(){Content = "Saved!"};
            try
            {
                var order = _orderService.GetAll().FirstOrDefault(e => e.Id == orderId);
                order.State = orderState;
                if (!_orderService.UpdateOrder(order))
                    res.Content = "Error occured";
            }
            catch
            {
                res.Content = "Error occured";
            }

            return res;
        }
    }
}