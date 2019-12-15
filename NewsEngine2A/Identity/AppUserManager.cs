using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using NewsEngine2A.Context;
using NewsEngine2A.Models;
using NewsEngine2A.Models.User;

namespace NewsEngine2A.Identity
{
    public class AppUserManager : UserManager<User, int>
    {
        public AppUserManager(IAppUserStore store) : base(store)
        { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            AppUserManager manager = new AppUserManager(new AppUserStore(context.Get<NewsEngineContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            // Configure validation logic for passwords
            /*manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };*/

            IDataProtectionProvider dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("Security Token Provider"));

            return manager;
        }
    }
}