using NewsEngine2A.Context;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly NewsEngineContext _context = new NewsEngineContext();
        public ActionResult CategoryList(string categoryName)
        {
            var articles = _context.Articles.Where(a => a.NewsCategory.Name.Equals(categoryName)).ToList();

            ViewBag.RecentNews = _context.Articles.OrderByDescending(a => a.CreateDate).Take(4).ToList();

            return View(articles);
        }
        public ActionResult CategoryGrid(string categoryName)
        {
            var articles = _context.Articles.Where(a => a.NewsCategory.Name.Equals(categoryName)).ToList();

            ViewBag.RecentNews = _context.Articles.OrderByDescending(a => a.CreateDate).Take(4).ToList();

            return View(articles);
        }

        public ActionResult SinglePost(int articleId)
        {
            var articles = _context.Articles.Where(a => a.Id == articleId).ToList();
            DateTime date = articles[0].CreateDate;
            var prevArticle = _context.Articles.Where(a => a.CreateDate < date)
                .OrderByDescending(a => a.CreateDate).FirstOrDefault();
            var nextArticle = _context.Articles.Where(a => a.CreateDate > date)
                .OrderBy(a => a.CreateDate).FirstOrDefault();
            articles.Add(prevArticle);
            articles.Add(nextArticle);

            return View(articles);
        }
    }
}