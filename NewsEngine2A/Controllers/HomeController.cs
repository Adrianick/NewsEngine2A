using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("About/{it:regex(^\\d{4}$)}/{id?}")]
        public ActionResult About(int it, int? id)
        {
            ViewBag.Message = "Your application description page."+it;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}