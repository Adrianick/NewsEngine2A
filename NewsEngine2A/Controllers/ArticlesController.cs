using NewsEngine2A.Context;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly NewsEngineContext _context = new NewsEngineContext();
        public ActionResult CategoryList(string categoryName = "Technology", string orderBy = null)
        {
            var articles = _context.Articles.Where(a => a.NewsCategory.Name.Equals(categoryName)).ToList();

            if (orderBy != null)
            {
                if (orderBy == "name")
                    articles = articles.OrderBy(a => a.Title).ToList();
                if (orderBy == "date")
                    articles = articles.OrderBy(a => a.CreateDate).ToList();
            }

            ViewBag.RecentNews = _context.Articles.OrderByDescending(a => a.CreateDate).Take(4).ToList();

            return View(articles);
        }
        public ActionResult CategoryGrid(string categoryName = "Technology", string orderBy = null)
        {
            var articles = _context.Articles.Where(a => a.NewsCategory.Name.Equals(categoryName)).ToList();

            if (orderBy != null)
            {
                if (orderBy == "name")
                    articles = articles.OrderBy(a => a.Title).ToList();
                if (orderBy == "date")
                    articles = articles.OrderBy(a => a.CreateDate).ToList();
            }

            ViewBag.RecentNews = _context.Articles.OrderByDescending(a => a.CreateDate).Take(4).ToList();

            return View(articles);
        }

        public ActionResult SinglePost(int articleId = 5)
        {
            var articles = _context.Articles.Where(a => a.Id == articleId).ToList();
            DateTime date = articles[0].CreateDate;
            int idPrincipal = articles[0].Id;
            var prevArticle = _context.Articles.Where(a => a.CreateDate < date && a.Id != idPrincipal)
                .OrderByDescending(a => a.CreateDate).FirstOrDefault();
            var nextArticle = _context.Articles.Where(a => a.CreateDate > date && a.Id != idPrincipal)
                .OrderBy(a => a.CreateDate).FirstOrDefault();



            if (prevArticle == null)
            {
                prevArticle = _context.Articles.OrderByDescending(a => a.CreateDate).FirstOrDefault();
            }
            if (nextArticle == null)
            {
                nextArticle = _context.Articles.OrderBy(a => a.CreateDate).FirstOrDefault();
            }
            articles.Add(prevArticle);
            articles.Add(nextArticle);

            return View(articles);
        }

        public ActionResult LookForArticle(string articleName = null)
        {

            return View(SinglePost(5));
        }
    }
}