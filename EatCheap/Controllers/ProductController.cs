using Entity;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EatCheap.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager productManager;
        private readonly BusinessManager businessManager;

        public ProductController()
        {
            this.productManager = new ProductManager();
            this.businessManager = new BusinessManager();
        }


        // GET: Product
        public ActionResult Index(int id)
        {
            var result = new Result<IEnumerable<Product>>();
            ViewBag.BusinessId = id;
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

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var result = new Result<Product>();
            var returnResult = productManager.FindById(id);
            try
            {
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = returnResult.Data;
                    return View(result.Data);
                }
            }
            catch (Exception)
            {
                
                return View("Error");
            }
            return View();
        }

        // GET: Product/Create
        public ActionResult Create(int businessId)
        {
            ViewBag.BusinessId = businessId;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Images/" + file.FileName);
            file.SaveAs(path);
            product.photo = "~/Images/" + file.FileName;
            try
            {               
                product.ourPrice = product.price * .90;
                productManager.Create(product);
                return RedirectToAction("Index", new { id = product.businessId });
            }
            catch
            {
                return View("ERROR");
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var result = new Result<Product>();
            try
            {
                if (result.Ststus == ResultStatus.Success)
                {
                    result.Data = productManager.FindById(id).Data;
                    return View(result.Data);
                }
                
            }
            catch (Exception)
            {

                return View("NOT FOUND"); 
            }
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product, HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Images/" + file.FileName);
            file.SaveAs(path);
            product.photo = "~/Images/" + file.FileName;

            product.id = id;
            int businessId = product.businessId;
            product.ourPrice = product.price * .9;
            try
            {
                productManager.Update(product);

                return RedirectToAction("Index", new { id = businessId });
            }
            catch
            {
                return View("ERROR");
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productManager.FindById(id);
            return View(product.Data);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
           
            try
            {
                product = productManager.FindById(id).Data;
                productManager.Remove(product);

                return RedirectToAction("Index", new { id = product.businessId } );
            }
            catch
            {
                return View();
            }
        }
    }
}
