using Manager;
using System.Web.Mvc;

namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusinessManager businessManager;
        public HomeController()
        {
            this.businessManager = new BusinessManager();
        }       


        public ActionResult Index()
        {
            var result = businessManager.FindAll();
            if (result.Ststus == ResultStatus.Success)
            {
                return View("Index", result.Data);
            }
            return Content("NO RESULTS FOUND");         
        }

     
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
