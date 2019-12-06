namespace NewsEngine2A.Context.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Headline = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EditDate = c.DateTime(),
                        PictureUrl = c.String(),
                        NewsCategoryId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategoryId)
                .Index(t => t.NewsCategoryId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        EditDate = c.DateTime(),
                        AuthorId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 450),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        PasswordHash = c.String(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true)
                .Index(t => t.PhoneNumber, unique: true, name: "IX_Phone");
            
            CreateTable(
                "dbo.AppUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AppUserLogins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 512),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "NewsCategoryId", "dbo.NewsCategories");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AppUserLogins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.AppUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.NewsCategories", new[] { "Name" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.AppUserLogins", new[] { "User_Id" });
            DropIndex("dbo.AppUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "IX_Phone");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropIndex("dbo.Articles", new[] { "NewsCategoryId" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.AppUserLogins");
            DropTable("dbo.AppUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
