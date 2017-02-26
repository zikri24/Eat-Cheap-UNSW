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
    public class BusinessReviewController : Controller
    {
        private readonly BusinessReviewManager reviewManager;

        public BusinessReviewController()
        {
            this.reviewManager = new BusinessReviewManager();            
        }


        // GET: BusinessReview
        public ActionResult Index(int businessId)
        {
            ViewBag.BusinessId = businessId;

            var result = new Result<IEnumerable<BusinessReview>>();
            try
            {
                var returnResult = reviewManager.FindByBusinessId(businessId).Data;
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

        // GET: BusinessReview/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessReview/Create
        public ActionResult Create(int businessId)
        {
            ViewBag.BusinessId = businessId;
            return View();
        }

       // POST: BusinessReview/Create
        [HttpPost]
        public ActionResult Create(ReviewVM reviewVM, int businessId)
        {
            BusinessReview review = new BusinessReview()
            {
                Review = reviewVM.Review,
                BusinessId = businessId
            };
        
            try
            {
                reviewManager.Create(review);
                return RedirectToAction("Index", new { businessId = businessId });
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: BusinessReview/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusinessReview/Edit/5
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

        // GET: BusinessReview/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessReview/Delete/5
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
