using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Entity;
using Manager;
using EatCheap.Models;




namespace EatCheap.Controllers
{

    [Authorize(Roles = "Business, Admin")]
    public class BusinessController : Controller
    {
        private readonly BusinessManager businessManager;
        public BusinessController()
        {
            this.businessManager = new BusinessManager();
        }       

      

        // GET: Businesses1
        [Authorize(Roles="Admin")]
        public ActionResult AdminIndex()
        {            
            var result = businessManager.FindAll();
            if (result.Ststus == ResultStatus.Success)
            {
                return View("Index", result.Data);
            }
            return Content("NO RESULTS FOUND");
        }
      
        public ActionResult Index()
        {
            var userName = User.Identity.Name;
            var result = businessManager.FindByUserName(userName);
            if (result.Ststus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return Content("NO RESULTS FOUND");
        }
        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(BusinessVM businessVM, HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Images/" + file.FileName);
            file.SaveAs(path);
           
            var email = "";
            var user = User.IsInRole("Admin");
            if (user)
            {
                email = businessVM.email; 
            }
            else
            {
                email = User.Identity.Name;
            }
            
            try
            {
                Business business = new Business()
                {
                    name = businessVM.name,
                    abn = businessVM.abn,
                    BusinesTtype = businessVM.businesTtype,
                    phone = businessVM.phone,
                    mobile = businessVM.mobile,
                    email = email,                    
                    city = businessVM.city,
                    streetNumber = businessVM.streetNumber,
                    foodCourt = businessVM.foodCourt,
                    building = businessVM.building,
                    photo = "~/Images/" + file.FileName
                    
                };

                businessManager.Create(business);
               
                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/Edit/5
        public ActionResult Edit(int id)
        {           
            Business business = businessManager.FindById(id).Data;
            /*businessVm.name = business.name;
            businessVm.phone = business.phone;
            businessVm.state = business.state;
            businessVm.streetNumber = business.streetNumber;
            businessVm.foodCourt = business.foodCourt;
            businessVm.email = business.email;
            businessVm.building = business.building;
            businessVm.abn = business.abn;*/

            return View(business);
        }

        // POST: Business/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Business business, HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/Images/" + file.FileName);
            file.SaveAs(path);

            business.id = id;
            business.email = User.Identity.Name;
            business.photo = "~/Images/" + file.FileName;
            try
            {
                businessManager.Update(business);   
                /*Business business = new Business()
                {                    
                    name = businessVM.name,
                    abn = businessVM.abn,
                    businesTtype = businessVM.businesTtype,
                    phone = businessVM.phone,
                    mobile = businessVM.mobile,
                    email = WebSecurity.CurrentUserName,
                    state = businessVM.state,
                    city = businessVM.city,
                    streetNumber = businessVM.streetNumber,
                    foodCourt = businessVM.foodCourt,
                    building = businessVM.building
                };*/   

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Business/Delete/5
        public ActionResult Delete(int id)
        {
            var result = new Result<Business>();
            Business business = new Business();
            try
            {
                if (result.Ststus == ResultStatus.Success)
                {
                    business = businessManager.FindById(id).Data;
                }
                else
                {
                    result.Ststus = ResultStatus.Error;
                }                

            }
            catch (Exception)
            {
                
              return View("NOT FOUND");
            }
            return View(business);
        }

        // POST: Business/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Business business)
        {
            try
            {
               business = businessManager.FindById(id).Data;
                businessManager.Remove(business);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CAN't DELETE");
            }
        }

        // GET: Menu/Details/5
        public ActionResult Details(int id)
        {
            Business business = new Business();
            try
            {
                business = businessManager.FindById(id).Data;
            }
            catch (Exception)
            {
                
                throw;
            }
            return View(business);
        }



       
    }
}
