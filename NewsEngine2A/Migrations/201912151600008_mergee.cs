namespace NewsEngine2A.Context.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergee : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Articles", "Headline", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Articles", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Content", c => c.String());
            AlterColumn("dbo.Articles", "Headline", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
