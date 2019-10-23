using NewsEngine2A.Context;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models.User;
using System;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        public ActionResult Register(int id = 0)
        {
            ViewBag.Message = "Your REGISTERERERERERERERERER page." + id;

            UserRegister newUser = new UserRegister();

            ViewBag.confirm = "";
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(UserRegister user)
        {
            NewsEngineContext context = new NewsEngineContext();

            User newUser = new User()
            {
                Id = 11,
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

            return View("Register/" + newUser.Id);
        }


    }

}