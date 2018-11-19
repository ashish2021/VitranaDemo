using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace vitiranaDemo.Controllers
{
    public class HomeController : Controller
    {
      
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "This can be viewed only by authenticated users only !";
            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult About()
        {
            ViewBag.Message = "This can be viewed only by users in User role only !";
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "This can be viewed only by users in Admin role only";
            return View();
        }
    }
}