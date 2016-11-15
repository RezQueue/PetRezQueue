namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Username", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Customers", "EmailID", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "CustomerLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerLocation", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
            DropColumn("dbo.Customers", "EmailID");
            DropColumn("dbo.Customers", "ConfirmPassword");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Username");
        }
    }
}
