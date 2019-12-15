using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Models.News;
using NewsEngine2A.Models.User;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NewsEngine2A.Context
{
    public class NewsEngineContext : IdentityDbContext//<User, Role, int, AppUserLogin, UserRole, AppUserClaim>
    {
        public NewsEngineContext() : base("name=NewsEngineContext")
        {
        }

        //public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public static NewsEngineContext Create()
        {
            return new NewsEngineContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AppUserLogin>().HasKey<int>(l => l.UserId);
            //modelBuilder.Entity<Role>().HasKey<int>(r => r.Id).ToTable("Roles");
            //modelBuilder.Entity<UserRole>().HasKey(r => new { r.RoleId, r.UserId }).ToTable("UserRoles");
            //modelBuilder.Entity<User>().ToTable("Users");

            //modelBuilder.Entity<Article>()
            //    .HasMany(u => u.Comments)
            //    .WithRequired(u => u.ArticleId)
            //    .WillCascadeOnDelete(true);

            modelBuilder.Entity<NewsCategory>()
                .ToTable("NewsCategories");

            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles");

            modelBuilder.Entity<Role>()
                .ToTable("Roles");
        }

        //public System.Data.Entity.DbSet<NewsEngine2A.Models.User.UserRegister> UserRegisters { get; set; }

        //public System.Data.Entity.DbSet<NewsEngine2A.Models.User.UserLogin> UserLogins { get; set; }
    }
}