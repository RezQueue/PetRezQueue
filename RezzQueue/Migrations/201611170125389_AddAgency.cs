namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgency : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        AgencyId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        ConfirmPassword = c.String(),
                        AgencyName = c.String(nullable: false),
                        EmailID = c.String(),
                        AgencyLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AgencyId);
            
            AddColumn("dbo.Animals", "Agency_AgencyId", c => c.Int());
            CreateIndex("dbo.Animals", "Agency_AgencyId");
            AddForeignKey("dbo.Animals", "Agency_AgencyId", "dbo.Agencies", "AgencyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Agency_AgencyId", "dbo.Agencies");
            DropIndex("dbo.Animals", new[] { "Agency_AgencyId" });
            DropColumn("dbo.Animals", "Agency_AgencyId");
            DropTable("dbo.Agencies");
        }
    }
}
