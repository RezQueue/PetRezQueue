namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAgencyName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "AgencyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "AgencyName", c => c.String());
        }
    }
}
