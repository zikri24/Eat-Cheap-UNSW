using Entity;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatCheap.Controllers
{
    public class UserProductController : Controller
    {
        private readonly ProductManager productManager;

        public UserProductController()
        {
            this.productManager = new ProductManager();            
        }

        // GET: UserProduct
        public ActionResult Index(int id)
        {
            var result = new Result<IEnumerable<Product>>();
            try
            {
                var returnResult = productManager.FindByBusinessId(id);
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = returnResult.Data;
                    return View(result.Data);
                }
                ViewBag.BusinessId = id;
            }
            catch (Exception)
            {
                return View("NOT FOUND");
            }
                return View(new { businessId = id });            
        }

        // GET: UserProduct/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProduct/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProduct/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProduct/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserProduct/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProduct/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
