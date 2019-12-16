namespace NewsEngine2A.Context.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActiveArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IsActive", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "IsActive");
        }
    }
}
