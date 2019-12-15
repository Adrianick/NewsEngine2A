using NewsEngine2A.Context;
using NewsEngine2A.Models.News;
using System;
using System.Linq;
using System.Threading.Tasks;
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

            ViewBag.Comments = _context.Comments.Where(c => c.ArticleId == articleId).ToList();

            return View(articles);
        }

        public async Task<ActionResult> AddComment(string message, int articleId, int authorId)
        {
            Comment newComment = new Comment()
            {
                ArticleId = articleId,
                AuthorId = authorId,
                CreateDate = DateTime.UtcNow,
                Content = message
            };
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();

            return RedirectToAction("SinglePost", new { articleId = articleId });
        }

        public async Task<ActionResult> DeleteComment(int commentId, int articleId)
        {
            var theComment = _context.Comments.FirstOrDefault(x => x.Id == commentId);
            if (theComment != null)
            {
                _context.Comments.Remove(theComment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("SinglePost", new { articleId = articleId });
        }

        public async Task<ActionResult> EditComment(int commentId, int articleId, string newContent)
        {
            var theComment = _context.Comments.FirstOrDefault(x => x.Id == commentId);
            if (theComment != null)
            {
                theComment.Content = newContent;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("SinglePost", new { articleId = articleId });
        }
    }
}