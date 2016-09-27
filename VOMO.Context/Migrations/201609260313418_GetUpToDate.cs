namespace VOMO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetUpToDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DisplayName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DisplayName", c => c.String(nullable: false));
        }
    }
}
