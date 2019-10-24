using NewsEngine2A.Context;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models.User;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace NewsEngine2A.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        // GET: User
        //[Route("login")]
        //public ActionResult Login()
        //{

        //    return View("~/Views/Home/Index.cshtml");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin objUser)
        {
            if (ModelState.IsValid)
            {
                NewsEngineContext context = new NewsEngineContext();

                var obj = context.Users.Where(a => a.Email.Equals(objUser.Email)).FirstOrDefault();

                if (!obj.Password.EncryptUserPassword().Equals(objUser.Password))
                {
                }
                
                if (!obj.Password.DecryptUserPassword().Equals(objUser.Password))
                {
                    return RedirectToAction("Login");
                }

                if (obj != null)
                {
                    Session["UserID"] = obj.Id.ToString();
                    Session["UserName"] = obj.Name.ToString();
                    return RedirectToAction("Login");
                }

            }
            return View(objUser);
        }

        public ActionResult Login()
        {

            return View();
        }


        [Route("register/{id?}")]
        public ActionResult Register(int id = 0)
        {

            return View();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(UserRegister user)
        {
            NewsEngineContext context = new NewsEngineContext();

            if (!IsValidEmail(user.Email))
            {
                ViewBag.EmailExists = "Invalid email address!";
                return View("Register");
            }

            if (context.Users.Any(u => u.Email.Equals(user.Email)))
            {
                ViewBag.EmailExists = "Email already exists!";
                return View("Register");
            }

            if (context.Users.Any(u => u.Phone.Equals(user.Phone)))
            {
                ViewBag.EmailExists = "Phone number already exists!";
                return View("Register");
            }

            User newUser = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Phone = user.Phone,
                Password = user.Password.EncryptUserPassword()
            };
            try
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var s = 0;
            }
            ModelState.Clear();

            return View("Register");
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}