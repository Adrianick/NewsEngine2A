using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Context;
using NewsEngine2A.Models.User;

namespace NewsEngine2A.Identity
{
    public interface IAppUserStore : IUserStore<User, string>
    {

    }

    public class AppUserStore : UserStore<User>,//<User, Role, int, AppUserLogin, UserRole, AppUserClaim>,
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
