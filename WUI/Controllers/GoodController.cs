using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace WUI.Controllers
{
    public class GoodController : Controller
    {
        private readonly GoodsService _goodsService;

        public GoodController(GoodsService goodsService)
        {
            _goodsService = goodsService;
        }
        
        // GET: Good/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            IActionResult result = null;
            try
            {
                var good = _goodsService.GetById(id);
                result = PartialView("Details", _goodsService.GetById(id));
            }
            catch(Exception ex)
            {
                result = new ContentResult();
                ((ContentResult) result).Content = "Good not found!";
            }

            return result;
        }

        // GET: Good/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Good/Create
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

        // GET: Good/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Good/Edit/5
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

        // GET: Good/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Good/Delete/5
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