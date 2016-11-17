namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "AnimalLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "AnimalLocation");
        }
    }
}
