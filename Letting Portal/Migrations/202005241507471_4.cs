namespace Letting_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String());
            DropColumn("dbo.AspNetUsers", "Postcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
        }
    }
}
