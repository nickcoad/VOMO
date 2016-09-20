namespace VOMO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraUserFields : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "Users");
            DropIndex("dbo.Users", "UserNameIndex");
            AddColumn("dbo.Users", "GivenName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Surname", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "DisplayName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 256));
            DropColumn("dbo.Users", "DisplayName");
            DropColumn("dbo.Users", "Surname");
            DropColumn("dbo.Users", "GivenName");
            CreateIndex("dbo.Users", "UserName", unique: true, name: "UserNameIndex");
            RenameTable(name: "dbo.Users", newName: "AspNetUsers");
        }
    }
}
