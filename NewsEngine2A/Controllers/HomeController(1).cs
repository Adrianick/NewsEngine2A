//using NewsEngine2A.Context;
//using System.Web.Mvc;

//namespace NewsEngine2A.Controllers
//{
//    [RoutePrefix("Home")]
//    public class HomeController : Controller
//    {
//        public ActionResult Index()
//        {


//            NewsEngineContext context = new NewsEngineContext();



//            //UserRegister newRegister = new UserRegister()
//            //{
//            //    Id = 1,
//            //    ConfirmPassword = "222333444f",
//            //    Password = "222333444f",
//            //    Email = "23421@21.234",
//            //    Phone = "1231231234",
//            //    Name = "gda",
//            //    Surname = "gdaT"
//            //};

//            //UserLogin nUserLogin = new UserLogin()
//            //{
//            //    Id = 1,
//            //    Email = "23421@21.234",
//            //    Password = "123123123f"
//            //};
//            //context.UserLogins.Add(nUserLogin);
//            //context.UserRegisters.Add(newRegister);
//            //context.SaveChanges();

//            //if (!context.Roles.Any())
//            //{
//            //    Role candidate = new Role
//            //    {
//            //        Id = 1,
//            //        Name = UserRoles.Unregistered,
//            //    };
//            //    context.Roles.Add(candidate);
//            //    Role company = new Role
//            //    {
//            //        Id = 2,
//            //        Name = UserRoles.Registered,
//            //    };
//            //    context.Roles.Add(company);
//            //    Role editor = new Role
//            //    {
//            //        Id = 3,
//            //        Name = UserRoles.Editor,
//            //    };
//            //    context.Roles.Add(editor);
//            //    Role admin = new Role
//            //    {
//            //        Id = 4,
//            //        Name = UserRoles.Admin,
//            //    };
//            //    context.Roles.Add(admin);
//            //    context.SaveChanges();
//            //}

//            //if (!context.Users.Any())
//            //{

//            //    User newUser = new User()
//            //    {
//            //        Email = "adrian.danut.nicolae@gmail.com",
//            //        Name = "Adrian",
//            //        Surname = "Nicolae",
//            //        Phone = "07716771693",
//            //        Password = "0122100".EncryptUserPassword(),
//            //    };
//            //    context.Users.Add(newUser);

//            //    context.SaveChanges();

//            //    UserRole newRole = new UserRole
//            //    {
//            //        UserId = newUser.Id,
//            //        RoleId = 4
//            //    };
//            //    context.UserRoles.Add(newRole);
//            //    context.SaveChanges();


//            //    NewsCategory newNewsCategory = new NewsCategory()
//            //    {
//            //        Name = "Technology"
//            //    };
//            //    context.NewsCategories.Add(newNewsCategory);

//            //    context.SaveChanges();

//            //    Article newArticle = new Article()
//            //    {
//            //        Title = "Titluuu",
//            //        Headline = "Un articol smek",
//            //        Content = "Acest articol vb despre cat de smek e ssa fii smekk",
//            //        CreateDate = DateTime.Now,
//            //        NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
//            //        AuthorId = context.Users.FirstOrDefault().Id
//            //    };
//            //    context.Articles.Add(newArticle);

//            //    context.SaveChanges();

//            //    Comment comment = new Comment
//            //    {
//            //        Content = "Comentariu de adi",
//            //        CreateDate = DateTime.Now,
//            //        ArticleId = newArticle.Id,
//            //        AuthorId = newUser.Id
//            //    };

//            //    context.Comments.Add(comment);

//            //    context.SaveChanges();
//            //}

//            return View();
//        }

//        [HttpGet]
//        [Route("About/{it:regex(^\\d{4}$)}/{id?}")]
//        public ActionResult About(int it, int? id)
//        {
//            ViewBag.Message = "Your application description page." + it;

//            return View();
//        }

//        [Authorize]
//        public ActionResult Contact()
//        {
//            ViewBag.Message = "Your contact page.";

//            return View();
//        }

//    }
//}