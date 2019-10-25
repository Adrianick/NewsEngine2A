using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Models.News;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsEngine2A.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Article> Articles { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext()
            : base("UsersDbContext", throwIfV1Schema: false)
        {

        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        //    //modelBuilder.Entity<Article>()
        //    //    .HasMany(u => u.Comments)
        //    //    .WithRequired(u => u.ArticleId)
        //    //    .WillCascadeOnDelete(true);

        //    modelBuilder.Entity<NewsCategory>()
        //        .ToTable("NewsCategories");
        //}

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
    }
}