namespace NewsEngine2A.Context.Config
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOverride : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Users", new[] { "Phone" });
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Users", "PhoneNumber", unique: true, name: "IX_Phone");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 20));
            DropIndex("dbo.Users", "IX_Phone");
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Users", "PasswordHash", c => c.String());
            CreateIndex("dbo.Users", "Phone", unique: true);
        }
    }
}
