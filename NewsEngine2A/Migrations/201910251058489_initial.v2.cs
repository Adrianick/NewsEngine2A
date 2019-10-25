namespace NewsEngine2A.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialv2 : DbMigration
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
                        AuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsCategories", t => t.NewsCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
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
                        AuthorId = c.String(maxLength: 128),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.ArticleId);
            
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
            DropForeignKey("dbo.Articles", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "NewsCategoryId", "dbo.NewsCategories");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.NewsCategories", new[] { "Name" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Articles", new[] { "AuthorId" });
            DropIndex("dbo.Articles", new[] { "NewsCategoryId" });
            DropTable("dbo.NewsCategories");
            DropTable("dbo.Comments");
            DropTable("dbo.Articles");
        }
    }
}
