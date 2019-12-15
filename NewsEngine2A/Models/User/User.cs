using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Models.News;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsEngine2A.Models.User
{
    public class User : IdentityUser//<int, AppUserLogin, UserRole, AppUserClaim>
    {
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Index("IX_Email", IsUnique = true)]
        [StringLength(450)]
        public override string Email { get; set; }

        [Index("IX_Phone", IsUnique = true)]
        [StringLength(20)]

        [Required]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public override string PasswordHash { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }
    //public class AppUserLogin : IdentityUserLogin<int> { }

    //public class AppUserRole : IdentityUserRole<int> { }

    //public class AppUserClaim : IdentityUserClaim<int> { }

    //public class AppRole : IdentityRole<int, AppUserRole> { }



}