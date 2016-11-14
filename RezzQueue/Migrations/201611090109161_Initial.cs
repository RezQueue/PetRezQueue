namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PetStatusAnimals", "PetStatus_PetStatusId", "dbo.PetStatus");
            DropForeignKey("dbo.PetStatusAnimals", "Animal_AnimalId", "dbo.Animals");
            DropIndex("dbo.PetStatusAnimals", new[] { "PetStatus_PetStatusId" });
            DropIndex("dbo.PetStatusAnimals", new[] { "Animal_AnimalId" });
            AddColumn("dbo.Animals", "PetStatus_PetStatusId", c => c.Int());
            CreateIndex("dbo.Animals", "PetStatus_PetStatusId");
            AddForeignKey("dbo.Animals", "PetStatus_PetStatusId", "dbo.PetStatus", "PetStatusId");
            DropColumn("dbo.Animals", "PetStatusId");
            DropTable("dbo.PetStatusAnimals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PetStatusAnimals",
                c => new
                    {
                        PetStatus_PetStatusId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetStatus_PetStatusId, t.Animal_AnimalId });
            
            AddColumn("dbo.Animals", "PetStatusId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Animals", "PetStatus_PetStatusId", "dbo.PetStatus");
            DropIndex("dbo.Animals", new[] { "PetStatus_PetStatusId" });
            DropColumn("dbo.Animals", "PetStatus_PetStatusId");
            CreateIndex("dbo.PetStatusAnimals", "Animal_AnimalId");
            CreateIndex("dbo.PetStatusAnimals", "PetStatus_PetStatusId");
            AddForeignKey("dbo.PetStatusAnimals", "Animal_AnimalId", "dbo.Animals", "AnimalId", cascadeDelete: true);
            AddForeignKey("dbo.PetStatusAnimals", "PetStatus_PetStatusId", "dbo.PetStatus", "PetStatusId", cascadeDelete: true);
        }
    }
}
