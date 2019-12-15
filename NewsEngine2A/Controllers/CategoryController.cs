using Microsoft.AspNet.Identity;
using NewsEngine2A.Context;
using NewsEngine2A.Models.News;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class CategoryController : Controller
    {
        NewsEngineContext db = new NewsEngineContext();

        // GET: /admin/categories
        // permissions: [admin, editor]
        [Route("admin/categories")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Index()
        {
            var categories = db.NewsCategories;
            ViewBag.categories = categories;

            return View("AdminIndex", masterName: "AdminLayout");
        }

        // GET: /admin/category/new
        // permissions: [admin, editor]
        [Route("admin/category/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New()
        {
            return View("AdminNew", masterName: "AdminLayout");
        }

        // POST: /admin/category/new
        // permissions: [admin, editor]
        [HttpPost]
        [Route("admin/category/new")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult New(NewsCategory newCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (TryUpdateModel(newCategory))
                    {
                        db.NewsCategories.Add(newCategory);
                        db.SaveChanges();
                        TempData["message"] = "Category was successfully added!";
                        TempData["type"] = "success";
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Category was not successfully added!";
                    TempData["type"] = "danger";
                    return View("AdminNew", masterName: "AdminLayout", newCategory);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return View("AdminNew", masterName: "AdminLayout");
            }
        }

        // POST: /admin/category/delete/{id}
        // permissions: [admin, editor]
        [HttpDelete]
        [Route("admin/category/delete/{id}")]
        [Authorize(Roles = "Admin, Editor")]
        public ActionResult Delete(int id)
        {
            NewsCategory category = db.NewsCategories.Find(id);

            TempData["message"] = "The category with the title " + category.Name + " was removed!";
            TempData["type"] = "warning";

            db.NewsCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}