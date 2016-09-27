namespace VOMO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStubToSlug : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Slug", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Tags", "Stub");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Stub", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Tags", "Slug");
        }
    }
}
