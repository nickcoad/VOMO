namespace VOMO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditFieldsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "CreatedAt");
        }
    }
}
