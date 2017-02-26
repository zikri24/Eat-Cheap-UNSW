using EatCheap.Models;
using Entity;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatCheap.Controllers
{
    [Authorize]
    public class ProductReviewController : Controller
    {
        private readonly ProductReviewManager reviewManager;

        public ProductReviewController()
        {
            this.reviewManager = new ProductReviewManager();            
        }

        // GET: ProductReview
        public ActionResult Index(int productId, int businessId)
        {

            ViewBag.ProductId = productId;
            ViewBag.BusinessId = businessId;
            var result = new Result<IEnumerable<ProductReview>>();
            try
            {
                var returnResult = reviewManager.FindByBusinessId(productId).Data;
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = returnResult;
                    return View(result.Data);
                }
            }
            catch
            {
                return View("NOT FOUND");
            }
            return View();
        }

        // GET: ProductReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductReview/Create
        public ActionResult Create(int productId, int businessId)
        {
            ViewBag.ProductId = productId;
            ViewBag.BusinessId = businessId;
            return View();
        }

        // POST: ProductReview/Create
        [HttpPost]
        public ActionResult Create(ReviewVM reviewVM, int productId, int businessId)
        {
            var review = new ProductReview()
            {
                Review = reviewVM.Review,
                ProductId = productId
            };

            try
            {
                reviewManager.Create(review);
                return RedirectToAction("Index", new { productId = productId, businessId = businessId });
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: ProductReview/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductReview/Edit/5
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

        // GET: ProductReview/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductReview/Delete/5
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
