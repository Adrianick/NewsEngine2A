using NewsEngine2A.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NewsEngine2A.Models.News;
using System.Diagnostics;

namespace NewsEngine2A.Controllers
{
    public class CommentController : Controller
    {

        NewsEngineContext db = new NewsEngineContext();

        // GET: /admin/comments
        // permissions: [admin, editor]
        [Route("admin/comments")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Index()
        {
            var comments = db.Comments.Include("User");
            ViewBag.comments = comments;

            return View("AdminIndex", masterName: "AdminLayout");
        }

        // GET: /admin/comment/new
        // permissions: [admin, editor]
        [Route("admin/comment/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New()
        { 
            List<SelectListItem> items = new List<SelectListItem>();
            var articles = db.Articles.Include("User");

            foreach (var article in articles)
            {
                items.Add(new SelectListItem
                {
                    Value = article.Id.ToString(),
                    Text = "Title: " + article.Title.ToString() + " | Author:" + article.User.Name
                });
            }

            ViewBag.articles = items;

            return View("AdminNew", masterName: "AdminLayout");
        }

        // POST: /admin/article/new
        // permissions: [admin, editor]
        [HttpPost]
        [Route("admin/comment/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New(Comment newComment)
        {
            try
            {

                List<SelectListItem> items = new List<SelectListItem>();
                var articles = db.Articles.Include("User");

                foreach (var article in articles)
                {
                    items.Add(new SelectListItem
                    {
                        Value = article.Id.ToString(),
                        Text = "Title: " + article.Title.ToString() + " | Author:" + article.User.Name
                    });
                }

                ViewBag.articles = items;

                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(newComment))
                    {
                        int id;
                        newComment.AuthorId = Int32.TryParse(User.Identity.GetUserId(), out id) ? id : (int)-1;

                        Debug.WriteLine("IDDD: " + id);


                        db.Comments.Add(newComment);
                        db.SaveChanges();
                        TempData["message"] = "Comment was successfully added!";
                        TempData["type"] = "success";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Comment was not successfully added!";
                    TempData["type"] = "danger";
                    return View("AdminNew", masterName: "AdminLayout", newComment);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View("AdminNew", masterName: "AdminLayout");
            }
        }

        // POST: /admin/comment/delete/{id}
        // permissions: [admin, editor]
        [HttpDelete]
        [Route("admin/comment/delete/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);

            if (User.IsInRole("Editor") && comment.AuthorId.ToString() != User.Identity.GetUserId())
            {
                TempData["message"] = "Hey don't try to delete comments from articles that aren't yours!";
                TempData["type"] = "warning";
            } else
            {
                TempData["message"] = "The comment was removed!";
                TempData["type"] = "warning";

                db.Comments.Remove(comment);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        // GET: /admin/comment/edit/{id}
        // permissions: [admin, editor]
        [HttpGet]
        [Route("admin/comment/edit/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id)
        {

            Comment comment = db.Comments.Find(id);

            if (User.IsInRole("Editor") && comment.AuthorId.ToString() != User.Identity.GetUserId())
            {
                TempData["message"] = "Hey don't try to edit comments from articles that aren't yours!";
                TempData["type"] = "warning";

                return RedirectToAction("Index");
            }
            else
            {
                return View("AdminEdit", masterName: "AdminLayout", comment);
            }
        }

        // PUT: /admin/comment/edit/{id}/{article}
        // permissions: [admin, editor]
        [HttpPut]
        [Route("admin/comment/edit/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                Comment oldComment = db.Comments.Find(id);
                if (TryUpdateModel(oldComment))
                {
                    oldComment.Content = comment.Content;


                    //oldComment.NewsCategoryId = article.NewsCategoryId;
                    db.SaveChanges();
                }

                TempData["message"] = "Comment edited successfully";
                TempData["type"] = "success";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["message"] = "Comment was not edited successfully";
                TempData["type"] = "danger";

                return RedirectToAction("Index");
            }
        }
    }

    
}