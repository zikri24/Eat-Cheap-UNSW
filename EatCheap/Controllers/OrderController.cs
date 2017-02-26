using EatCheap.Models;
using Entity;
using Manager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatCheap.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ProductManager productManager;
        private readonly OrderManager orderManager;
        private readonly OrderItemManager orderItemManager;

        public OrderController() 
        {
            productManager = new ProductManager();
            orderManager = new OrderManager();
            orderItemManager = new OrderItemManager();
        }
        
        
        // GET: Order
        public ActionResult Index(int id, int businessId)
        {
            /*if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(productManager.FindById(id).Data));
                Session["Cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                cart.Add(new Item(productManager.FindById(id).Data));
                Session["Cart"] = cart;
            }*/
            if (Session["cart"] == null)
            {
                List<Product> cart = new List<Product>();
                cart.Add(productManager.FindById(id).Data);
                Session["cart"] = cart;
            }
            else
            {
                List<Product> cart = (List<Product>)Session["cart"];
                cart.Add(productManager.FindById(id).Data);
                Session["cart"] = cart;
            }

            return RedirectToAction("Index", "UserProduct", new { id = businessId });
        }
        public ActionResult Order()
        {
            if (Session["cart"] != null)
            {         
                double total = 0.0;
                List<Product> list = Session["cart"] as List<Product>;
                foreach (var item in list)
	            {
                    total += item.ourPrice;		 
	            }           

                Order order = new Order()
                {
                     Date = DateTime.Now,
                      Total = total
                };

                orderManager.Create(order);

                var result = orderManager.FindAll();
                var id = (from ids in result.Data orderby ids.Id descending select ids.Id).FirstOrDefault();
           

                foreach (var item in list)
                {
                    orderItemManager.Create(new OrderItem() { OrderId = id, ProductId = item.id });
                }

                bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["IsSandbox"]);
                var paypal = new PayPal(useSandbox);

                //paypal.item_name = product;
                paypal.amount = total;
                return View("ValidateCommand", paypal);
            }
            else
            {
                return View();
            }
           
        }

        // GET: Order/Details/5
        public ActionResult Cancel()
        {
            Session.Remove("cart");
            return RedirectToAction("Index", "Home");
        }
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

        // GET: Order/Edit/5
        public ActionResult Edit(int id, int businessId)
        {
            List<Product> cart = (List<Product>)Session["cart"];
            Product product = productManager.FindById(id).Data;
            cart.RemoveAll(x => x.id == id);
            Session["cart"] = cart;
            return RedirectToAction("Index", "UserProduct", new { id = businessId });
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
        public ActionResult RedirectFromPaypal()
        {
            return RedirectToAction( "Index","Home");
        }

        public ActionResult CancelFromPaypal()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult NotifyFromPaypal()
        {
            return View();
        }

    }
}
