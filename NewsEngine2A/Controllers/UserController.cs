using NewsEngine2A.Context;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models.User;
using System;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        // GET: User

        [Route("register/{id?}")]
        public ActionResult Register(int id = 0)
        {

            UserRegister newUser = new UserRegister();

            ViewBag.confirm = "";
            return View(newUser);
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