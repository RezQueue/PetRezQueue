namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "Agency_AgencyId", "dbo.Agencies");
            DropIndex("dbo.Animals", new[] { "Agency_AgencyId" });
            RenameColumn(table: "dbo.Animals", name: "Agency_AgencyId", newName: "AgencyId");
            AlterColumn("dbo.Animals", "AgencyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "AgencyId");
            AddForeignKey("dbo.Animals", "AgencyId", "dbo.Agencies", "AgencyId", cascadeDelete: true);
            DropColumn("dbo.Animals", "AgencyLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "AgencyLocation", c => c.String());
            DropForeignKey("dbo.Animals", "AgencyId", "dbo.Agencies");
            DropIndex("dbo.Animals", new[] { "AgencyId" });
            AlterColumn("dbo.Animals", "AgencyId", c => c.Int());
            RenameColumn(table: "dbo.Animals", name: "AgencyId", newName: "Agency_AgencyId");
            CreateIndex("dbo.Animals", "Agency_AgencyId");
            AddForeignKey("dbo.Animals", "Agency_AgencyId", "dbo.Agencies", "AgencyId");
        }
    }
}
