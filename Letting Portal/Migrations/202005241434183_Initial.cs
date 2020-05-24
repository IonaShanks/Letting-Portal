namespace Letting_Portal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            AddColumn("dbo.Rentals", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Fname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Lname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.Rentals", "Region", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false));
            CreateIndex("dbo.Rentals", "ApplicationUser_Id1");
            AddForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rentals", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rentals", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Rentals", "Region", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Postcode");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Lname");
            DropColumn("dbo.AspNetUsers", "Fname");
            DropColumn("dbo.Rentals", "ApplicationUser_Id1");
            AddForeignKey("dbo.Rentals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
