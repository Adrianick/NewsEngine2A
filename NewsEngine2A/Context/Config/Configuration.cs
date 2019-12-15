using System;
using System.Data.Entity.Migrations;
using System.Security.Cryptography;

namespace NewsEngine2A.Context.Config
{
    public sealed class Configuration : DbMigrationsConfiguration<NewsEngineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        protected override void Seed(NewsEngineContext context)
        {
            /*
             * Create roles if not existing
             */
            //if (!context.Roles.Any())
            //{
            //    System.Diagnostics.Debug.WriteLine("roles");
            //    Role candidate = new Role
            //    {
            //        Id = 1,
            //        Name = UserRoles.Unregistered,
            //    };
            //    context.Roles.Add(candidate);
            //    Role company = new Role
            //    {
            //        Id = 2,
            //        Name = UserRoles.Registered,
            //    };
            //    context.Roles.Add(company);
            //    Role editor = new Role
            //    {
            //        Id = 3,
            //        Name = UserRoles.Editor,
            //    };
            //    context.Roles.Add(editor);
            //    Role admin = new Role
            //    {
            //        Id = 4,
            //        Name = UserRoles.Admin,
            //    };
            //    context.Roles.Add(admin);
            //    context.SaveChanges();
            //}

            ///*
            // * Create a demo user admin 
            // */
            //if (!context.Users.Any(u => u.Name.Equals("admin")))
            //{

            //    User newUser = new User()
            //    {
            //        UserName = "admin@admin.com",
            //        Email = "admin@admin.com",
            //        Name = "admin",
            //        Surname = "admin",
            //        PhoneNumber = "0722222222",
            //        PasswordHash = HashPassword("admin123"),
            //        SecurityStamp = "stamp_security_123"
            //    };

            //    context.Users.Add(newUser);
            //    context.SaveChanges();

            //    UserRole newRole = new UserRole
            //    {
            //        UserId = newUser.Id,
            //        RoleId = 4
            //    };

            //    newUser.Roles.Add(newRole);

            //    context.Entry(newUser).State = System.Data.Entity.EntityState.Modified;
            //    context.SaveChanges();
            //}

            ///*
            // * Create a demo user editor 
            // */
            //if (!context.Users.Any(u => u.Name.Equals("editor")))
            //{

            //    User newUser = new User()
            //    {
            //        UserName = "editor@editor.com",
            //        Email = "editor@editor.com",
            //        Name = "editor",
            //        Surname = "editor",
            //        PhoneNumber = "07222222222",
            //        PasswordHash = HashPassword("admin123"),
            //        SecurityStamp = "stamp_security_123"
            //    };

            //    context.Users.Add(newUser);
            //    context.SaveChanges();

            //    UserRole newRole = new UserRole
            //    {
            //        UserId = newUser.Id,
            //        RoleId = 3
            //    };

            //    newUser.Roles.Add(newRole);

            //    context.Entry(newUser).State = System.Data.Entity.EntityState.Modified;
            //    context.SaveChanges();
            //}


            ///*
            // * Create some categories for test
            // */
            //if (!context.NewsCategories.Any())
            //{
            //    NewsCategory newNewsCategory = new NewsCategory()
            //    {
            //        Name = "Technology"
            //    };
            //    context.NewsCategories.Add(newNewsCategory);
            //    context.SaveChanges();
            //}

            ///*
            // * Create some articles for test
            // */
            //if (!context.Articles.Any())
            //{
            //    context.Articles.Add(new Article()
            //    {
            //        Title = "Titluuu",
            //        Headline = "Un articol smek",
            //        Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //        CreateDate = DateTime.Now,
            //        NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //        AuthorId = context.Users.FirstOrDefault().Id
            //    });

            //    context.Articles.Add(new Article()
            //    {
            //        Title = "Titluuu",
            //        Headline = "Un articol smek 2",
            //        Content = "Acest articol vb despre cat de smek e ssa fii smekk",
            //        CreateDate = DateTime.Now,
            //        NewsCategoryId = context.NewsCategories.FirstOrDefault().Id,
            //        AuthorId = context.Users.FirstOrDefault().Id
            //    });

            //    context.SaveChanges();
            //}

        }
    }
}