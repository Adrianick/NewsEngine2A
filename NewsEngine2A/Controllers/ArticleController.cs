using Microsoft.AspNet.Identity;
using NewsEngine2A.Context;
using NewsEngine2A.Models.News;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace NewsEngine2A.Controllers
{
    public class ArticleController : Controller
    {
        NewsEngineContext db = new NewsEngineContext();

        // GET: /admin
        // permissions: [admin, editor]
        [Route("admin")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AllArticles");
            } else
            {
                int id = Int32.Parse(User.Identity.GetUserId());
                return Redirect("/articles/" + id);
            }
        }

        // GET: /admin/articles
        // permissions: [admin]
        [Route("admin/articles")]
        [Authorize(Roles = "Admin")]
        public ActionResult AllArticles()
        {
            var articles = db.Articles.Include("NewsCategory").Include("User");
            ViewBag.articles = articles;

            return View("AdminIndex", masterName: "AdminLayout");
        }

        // GET: /admin/articles/{id}
        // permissions: [editor]
        [Route("admin/articles/{id}")]
        [Authorize(Roles = "Editor")]
        public ActionResult MyArticles(int id)
        {
            var articles = db.Articles.Where(a => a.AuthorId == id).Include("NewsCategory").Include("User");
            ViewBag.articles = articles;

            return View("AdminIndex", masterName: "AdminLayout");
        }

        // GET: /admin/article/new
        // permissions: [admin, editor]
        [Route("admin/article/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            var categories = db.NewsCategories;

            foreach (var category in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name.ToString()
                });
            }

            ViewBag.categories = items;

            return View("AdminNew", masterName: "AdminLayout");
        }

        // POST: /admin/article/new
        // permissions: [admin, editor]
        [HttpPost]
        [Route("admin/article/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New(Article newArticle, HttpPostedFileBase upload)
        {
            try
            {

                List<SelectListItem> items = new List<SelectListItem>();
                var categories = db.NewsCategories;

                foreach (var category in categories)
                {
                    items.Add(new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name.ToString()
                    });
                }

                ViewBag.categories = items;

                if (ModelState.IsValid)
                {
                    Debug.WriteLine("STATE: " + TryUpdateModel(newArticle));
                    if (TryUpdateModel(newArticle))
                    {
                        int id;
                        newArticle.AuthorId = Int32.TryParse(User.Identity.GetUserId(), out id) ? id : (int)-1;

                        if (upload != null && upload.ContentLength > 0)
                        {
                            using (var reader = new System.IO.BinaryReader(upload.InputStream))
                            {
                                byte[] bytes = reader.ReadBytes(upload.ContentLength);
                                newArticle.PictureUrl = "data:image/png;base64," + Convert.ToBase64String(bytes);
                            }
                        }

                        db.Articles.Add(newArticle);
                        db.SaveChanges();
                        TempData["message"] = "Article was successfully added!";
                        TempData["type"] = "success";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Article was not successfully added!";
                    TempData["type"] = "danger";
                    return View("AdminNew", masterName: "AdminLayout", newArticle);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View("AdminNew", masterName: "AdminLayout");
            }
        }


        // POST: /admin/article/delete/{id}
        // permissions: [admin, editor]
        [HttpDelete]
        [Route("admin/article/delete/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);

            TempData["message"] = "The article with the title " + article.Title + " was removed!";
            TempData["type"] = "warning";

            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: /admin/article/edit/{id}
        // permissions: [admin, editor]
        [HttpGet]
        [Route("admin/article/edit/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);

            List<SelectListItem> items = new List<SelectListItem>();
            var categories = db.NewsCategories;

            foreach (var category in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name.ToString()
                });
            }

            ViewBag.categories = items;

            return View("AdminEdit", masterName: "AdminLayout", article);
        }

        // PUT: /admin/article/edit/{id}/{article}
        // permissions: [admin, editor]
        [HttpPut]
        [Route("admin/article/edit/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id, Article article, HttpPostedFileBase upload)
        {
            try
            {
                Article oldArticle = db.Articles.Find(id);
                if (TryUpdateModel(oldArticle))
                {
                    oldArticle.Title = article.Title;
                    oldArticle.Headline = article.Headline;
                    oldArticle.Content = article.Content;

                    if (upload != null && upload.ContentLength > 0)
                    {
                        using (var reader = new System.IO.BinaryReader(upload.InputStream))
                        {
                            byte[] bytes = reader.ReadBytes(upload.ContentLength);
                            oldArticle.PictureUrl = "data:image/png;base64," + Convert.ToBase64String(bytes);
                        }
                    }

                    oldArticle.NewsCategoryId = article.NewsCategoryId;
                    db.SaveChanges();
                }

                TempData["message"] = "Article edited successfully";
                TempData["type"] = "success";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["message"] = "Article was not edited successfully";
                TempData["type"] = "danger";

                return RedirectToAction("Index");
            }
        }
    }
}