using Microsoft.AspNet.Identity.EntityFramework;
using NewsEngine2A.Helpers.UserHelper;
using NewsEngine2A.Models.News;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
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
            if (!context.Roles.Any())
            {
                System.Diagnostics.Debug.WriteLine("roles");
                IdentityRole candidate = new IdentityRole()
                {
                    Name = UserRoles.Unregistered,
                };
                context.Roles.Add(candidate);
                IdentityRole company = new IdentityRole
                {
                    Name = UserRoles.Registered,
                };
                context.Roles.Add(company);
                IdentityRole editor = new IdentityRole
                {
                    Name = UserRoles.Editor,
                };
                context.Roles.Add(editor);
                IdentityRole admin = new IdentityRole
                {
                    Name = UserRoles.Admin,
                };
                context.Roles.Add(admin);
                context.SaveChanges();
            }

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

            ///


            if (!context.NewsCategories.Any())
            {
                context.NewsCategories.Add(new NewsCategory()
                {
                    Id = 1,
                    Name = "Technology"
                });
                context.NewsCategories.Add(new NewsCategory()
                {
                    Id = 2,
                    Name = "Politics"
                });
                context.NewsCategories.Add(new NewsCategory()
                {
                    Id = 3,
                    Name = "Sports"
                });

                context.SaveChanges();
            }


            if (!context.Articles.Any())
            {
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluuu1 ",
                //    Headline = "Un articol smek",
                //    Content = "2Acest articol vb despre cat de smek e ssa fii smekk",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 1,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluuu2",
                //    Headline = "Un articol tare 2",
                //    Content = "Acest articol nu e",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 2,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluu3",
                //    Headline = "Un articol tare 3",
                //    Content = "Doar nu e",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 2,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluu4",
                //    Headline = "Un articol tare 4",
                //    Content = "Doar nu e asd",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 3,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluu5",
                //    Headline = "Un articol tare 5",
                //    Content = "Doar nu e taree",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 2,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                //context.Articles.Add(new Article()
                //{
                //    Title = "Titluu6",
                //    Headline = "Un articol tare 6",
                //    Content = "Doar nu e tot",
                //    CreateDate = DateTime.Now,
                //    NewsCategoryId = 1,
                //    AuthorId = context.Users.FirstOrDefault().Id
                //});
                //context.SaveChanges();
                context.Articles.Add(new Article()
                {
                    Title = "Titlwuu7",
                    Headline = "Un articol tare 7",
                    Content = "Totsfgnhmghg asda d",
                    CreateDate = DateTime.Now,
                    NewsCategoryId = 1,
                    AuthorId = context.Users.FirstOrDefault().Id
                });
                context.SaveChanges();
                context.Articles.Add(new Article()
                {
                    Title = "DAitluu8",
                    Headline = "Un articol tare 8",
                    Content = "Doar nu e",
                    CreateDate = DateTime.Now,
                    NewsCategoryId = 1,
                    AuthorId = context.Users.FirstOrDefault().Id
                });
                context.SaveChanges();
                context.Articles.Add(new Article()
                {
                    Title = "ATitluu9",
                    Headline = "Un articol tare 9",
                    Content = "Doar nu are e",
                    CreateDate = DateTime.Now,
                    NewsCategoryId = 2,
                    AuthorId = context.Users.FirstOrDefault().Id
                });


                context.SaveChanges();
            }

        }
    }
}