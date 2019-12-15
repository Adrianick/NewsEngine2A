using NewsEngine2A.Identity;
using NewsEngine2A.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsEngine2A.Context;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NewsEngine2A.Controllers
{
    public class UsersController : Controller
    {
        NewsEngineContext db = new NewsEngineContext();

        private ApplicationSignInManager _signInManager;
        private AppUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(AppUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: /admin/users
        // permissions: [admin, editor]
        [Route("admin/users")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Index()
        {
            var users = await db.Users.ToListAsync();
            ViewBag.users = users;

            
            return View("AdminIndex", masterName: "AdminLayout");
        }
    }
}