using NewsEngine2A.Context;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models.News;
using NewsEngine2A.Models.User;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            NewsEngineContext context = new NewsEngineContext();


            if (!context.Users.Any())
            {

                User newUser = new User()
                {
                    Email = "adrian.danut.nicolae@gmail.com",
                    Name = "Adrian",
                    Surname = "Nicolae",
                    Phone = "07716771693",
                    Role = Helpers.UserHelper.UserRoles.Admin,
                    Password = "0122100".EncryptUserPassword()
                };
                context.Users.Add(newUser);

                NewsCategory newNewsCategory = new NewsCategory()
                {
                    Name = "Technology"
                };
                context.NewsCategories.Add(newNewsCategory);

                context.SaveChanges();

                Article newArticle = new Article()
                {
                    Title = "Titluuu",
                    Headline = "Un articol smek",
                    Content = "Acest articol vb despre cat de smek e ssa fii smekk",
                    CreateDate = DateTime.Now,
                    NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
                    AuthorId = context.Users.FirstOrDefault().Id
                };
                context.Articles.Add(newArticle);

                context.SaveChanges();
            }

            return View();
        }

        [HttpGet]
        [Route("About/{it:regex(^\\d{4}$)}/{id?}")]
        public ActionResult About(int it, int? id)
        {
            ViewBag.Message = "Your application description page." + it;

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}