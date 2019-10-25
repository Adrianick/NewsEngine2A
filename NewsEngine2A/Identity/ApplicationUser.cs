//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace NewsEngine2A.Identity
//{
//    public class ApplicationUser : IdentityUser<int, AppUserLogin, AppUserRole, AppUserClaim>, IUser<int>
//    {
//        public bool IsActive { get; set; }
//        public int? CompanyId { get; set; }
//        public int? AddressId { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public int Gender { get; set; }
//        public string CurrentJob { get; set; }
//        public DateTime? CreateDate { get; set; }
//        public DateTime? UpdateDate { get; set; }
//        public bool WantsNotification { get; set; }
//        public bool PrivateInformation { get; set; }
//        public string ShortDescription { get; set; }
//        public DateTime? BirthDate { get; set; }
//        public int Rating { get; set; }

//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUserManager manager,
//            string authenticationType)
//        {
//            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
//            userIdentity.AddClaim(new Claim("CompanyId", this.CompanyId.ToString()));
//            return userIdentity;
//        }
//    }

//    public class AppUserLogin : IdentityUserLogin<int> { }

//    public class AppUserRole : IdentityUserRole<int> { }

//    public class AppUserClaim : IdentityUserClaim<int> { }

//    public class AppRole : IdentityRole<int, AppUserRole> { }

//    public class AppClaimsPrincipal : ClaimsPrincipal
//    {
//        public AppClaimsPrincipal(ClaimsPrincipal principal) : base(principal)
//        { }

//        public int UserId
//        {
//            get { return int.Parse(this.FindFirst(ClaimTypes.Sid).Value); }
//        }
//    }
//}
