//using Microsoft.AspNet.Identity.EntityFramework;
//using NewsEngine2A.Models;
//using System.Data.Entity;

//namespace NewsEngine2A.Context
//{
//    public class UsersDbContext : IdentityDbContext<ApplicationUser>//, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
//    {
//        public UsersDbContext() : base("name=UsersDbContext")
//        {
//        }

//        public static UsersDbContext Create()
//        {
//            return new UsersDbContext();
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            this.Configuration.AutoDetectChangesEnabled = false;

//            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(p => p.Id);

//        //    modelBuilder.Entity<AppUserRole>().ToTable("UserRoles");
//        //    modelBuilder.Entity<AppUserLogin>().ToTable("UserLogins");
//        //    modelBuilder.Entity<AppUserClaim>().ToTable("UserClaims");
//        //    modelBuilder.Entity<AppRole>().ToTable("Roles");
//        }
//    }
//}