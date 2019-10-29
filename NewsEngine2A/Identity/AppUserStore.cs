using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Context;
using NewsEngine2A.Models;

namespace NewsEngine2A.Identity
{
    public interface IAppUserStore : IUserStore<ApplicationUser, string>
    {

    }

    public class AppUserStore : UserStore<ApplicationUser>,//, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>,
        IAppUserStore
    {
        public AppUserStore() : base(new NewsEngineContext())
        {

        }

        public AppUserStore(NewsEngineContext context) : base(context)
        {

        }
    }
}
