using NewsEngine2A.Context;
using System.Linq;
using System.Web.Mvc;

namespace NewsEngine2A.Controllers
{
    public class CategoriesPartialController : Controller
    {
        private readonly NewsEngineContext _context = new NewsEngineContext();
        public ActionResult NavCategories()
        {
            var categories = _context.NewsCategories.ToList();

            return PartialView(categories);
        }
    }
}