using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NewsEngine2A.Context;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models;
using NewsEngine2A.Models.News;
using NewsEngine2A.Models.User;

namespace NewsEngine2A.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View("~/Views/Article/AdminIndex.cshtml", masterName: "AdminLayout");
        }
    }
}