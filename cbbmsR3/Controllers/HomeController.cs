using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cbbmsR3.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //if (User.Identity.IsAuthenticated) { ViewBag.Message = "Current User ID :" + UserId.ToString(); }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}