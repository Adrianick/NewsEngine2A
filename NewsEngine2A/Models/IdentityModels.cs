using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Models.News;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using NewsEngine2A.Identity;

namespace NewsEngine2A.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser//<int, AppUserLogin, AppUserRole, AppUserClaim>, IUser<int>
    {


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager)//,string authenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            //ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            //userIdentity.AddClaim(new Claim("UserId", this.Id.ToString()));
            return userIdentity;
        }
    }

    //public class AppUserLogin : IdentityUserLogin<int> { }

    //public class AppUserRole : IdentityUserRole<int> { }

    //public class AppUserClaim : IdentityUserClaim<int> { }

    //public class AppRole : IdentityRole<int, AppUserRole> { }

    //public class AppClaimsPrincipal : ClaimsPrincipal
    //{
    //    public AppClaimsPrincipal(ClaimsPrincipal principal) : base(principal)
    //    { }

    //    public int UserId
    //    {
    //        get { return int.Parse(this.FindFirst(ClaimTypes.Sid).Value); }
    //    }
    //}

}