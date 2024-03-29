﻿using Microsoft.AspNet.Identity;
using NewsEngine2A.Context;
using NewsEngine2A.Models.News;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsEngineContext _context = new NewsEngineContext();
        public ActionResult Index(string search = null)
        {
            var articles = _context.Articles.OrderByDescending(a => a.CreateDate).ToList();
            var finalResult = new List<Article>();
            if (search != null)
            {
                var listSearch = search.Split();
                foreach (var s in listSearch)
                {
                    var tempArticles = articles.Where(a => (a.Title.Contains(s) || a.Content.Contains(s) || a.Headline.Contains(s))).ToList();
                    if (tempArticles != null)
                    {
                        finalResult.AddRange(tempArticles);
                    }
                }

                finalResult = finalResult.Distinct().ToList();
            }
            else
            {
                finalResult = articles;
            }

            ViewBag.ArticlesWithMostComments = articles.Where(a => a.Comments.Count > 0).OrderByDescending(a => a.Comments.Count).Take(3).ToList();

            return View(finalResult);
        }
        //[Authorize(Roles = "Admin")]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = User.Identity.GetUserId();




            return View();
        }

        public ActionResult Contact()
        {
            //NewsEngineContext context = new NewsEngineContext();

            //if (!context.Roles.Any())
            //{
            //    Role candidate = new Role
            //    {
            //        Id = 1,
            //        Name = UserRoles.Unregistered,
            //    };
            //    context.Roles.Add(candidate);
            //    Role company = new Role
            //    {
            //        Id = 2,
            //        Name = UserRoles.Registered,
            //    };
            //    context.Roles.Add(company);
            //    Role editor = new Role
            //    {
            //        Id = 3,
            //        Name = UserRoles.Editor,
            //    };
            //    context.Roles.Add(editor);
            //    Role admin = new Role
            //    {
            //        Id = 4,
            //        Name = UserRoles.Admin,
            //    };
            //    context.Roles.Add(admin);
            //    context.SaveChanges();


            //    if (!context.Users.Any())
            //    {
            //        UserRole newRole = new UserRole
            //        {
            //            //User = context.Users.FirstOrDefault(),
            //            //Role = context.Roles.FirstOrDefault(r => r.Name.ToLower().Equals("admin"))
            //            UserId = 1,
            //            RoleId = 4
            //        };

            //        //User newUser = new User()
            //        //{
            //        //    Email = "adrian.danut.nicolae@gmail.com",
            //        //    Name = "Adrian",
            //        //    Surname = "Nicolae",
            //        //    PhoneNumber = "07716771693",
            //        //    PasswordHash = "0122100",
            //        //    Roles = { newRole }
            //        //};
            //        //context.Users.Add(newUser);

            //        //context.SaveChanges();

            //        //UserRole newRole = new UserRole
            //        //{
            //        //    UserId = newUser.Id,
            //        //    RoleId = 4
            //        //};

            //        context.SaveChanges();


            //        NewsCategory newNewsCategory = new NewsCategory()
            //        {
            //            Name = "Technology"
            //        };
            //        context.NewsCategories.Add(newNewsCategory);

            //        context.SaveChanges();

            //        Article newArticle = new Article()
            //        {
            //            Title = "Titluuu",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now,
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);

            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu2",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);

            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu3",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);
            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu4",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);
            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu5",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);
            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu6",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);
            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu7",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);
            //        newArticle = new Article()
            //        {
            //            Title = "Titluuu8",
            //            Headline = "Un articol smek",
            //            Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //            CreateDate = DateTime.Now.AddMinutes(2),
            //            NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //            AuthorId = context.Users.FirstOrDefault().Id
            //        };
            //        context.Articles.Add(newArticle);


            //        context.SaveChanges();

            //        Comment comment = new Comment
            //        {
            //            Content = "Comentariu de adi",
            //            CreateDate = DateTime.Now,
            //            ArticleId = newArticle.Id,
            //            AuthorId = 1
            //        };

            //        context.Comments.Add(comment);

            //        context.SaveChanges();
            //    }
            //}

            return View();
        }
    }
}