﻿using NewsEngine2A.Models.News;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NewsEngine2A.Models.User;

namespace NewsEngine2A.Context
{
    public class NewsEngineContext : DbContext
    {
        public NewsEngineContext() : base("name=NewsEngineContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            //modelBuilder.Entity<Article>()
            //    .HasMany(u => u.Comments)
            //    .WithRequired(u => u.ArticleId)
            //    .WillCascadeOnDelete(true);

            modelBuilder.Entity<NewsCategory>()
                .ToTable("NewsCategories");
        }

        //public System.Data.Entity.DbSet<NewsEngine2A.Models.User.UserRegister> UserRegisters { get; set; }

        //public System.Data.Entity.DbSet<NewsEngine2A.Models.User.UserLogin> UserLogins { get; set; }
    }
}