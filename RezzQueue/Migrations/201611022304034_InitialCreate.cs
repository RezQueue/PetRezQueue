namespace RezzQueue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false, identity: true),
                        PetStatusId = c.Int(nullable: false),
                        SpeciesId = c.Int(nullable: false),
                        BreedId = c.Int(),
                        IconId = c.Int(),
                        AnimalName = c.String(),
                        AnimalAge = c.Int(),
                        AnimalSize = c.String(),
                        AnimalPrice = c.Int(),
                        AnimalPreview = c.String(),
                        AnimalPhoto = c.String(),
                        AnimalDesc = c.String(),
                        AgencyName = c.String(),
                        AgencyLocation = c.String(),
                        AgencyContact = c.String(),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Breeds", t => t.BreedId)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .Index(t => t.SpeciesId)
                .Index(t => t.BreedId);
            
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        BreedId = c.Int(nullable: false, identity: true),
                        BreedName = c.String(),
                        SpeciesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BreedId)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .Index(t => t.SpeciesId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        PetStatusId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerLocation = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.PetStatus",
                c => new
                    {
                        PetStatusId = c.Int(nullable: false, identity: true),
                        AnimalId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        HasSeen = c.Boolean(nullable: false),
                        Favorite = c.Boolean(nullable: false),
                        ThumbsDown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PetStatusId);
            
            CreateTable(
                "dbo.Icons",
                c => new
                    {
                        IconId = c.Int(nullable: false, identity: true),
                        IconName = c.String(),
                        IconGlyph = c.String(),
                    })
                .PrimaryKey(t => t.IconId);
            
            CreateTable(
                "dbo.CustomerAnimals",
                c => new
                    {
                        Customer_CustomerId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Animal_AnimalId })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Animal_AnimalId);
            
            CreateTable(
                "dbo.PetStatusAnimals",
                c => new
                    {
                        PetStatus_PetStatusId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetStatus_PetStatusId, t.Animal_AnimalId })
                .ForeignKey("dbo.PetStatus", t => t.PetStatus_PetStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId, cascadeDelete: true)
                .Index(t => t.PetStatus_PetStatusId)
                .Index(t => t.Animal_AnimalId);
            
            CreateTable(
                "dbo.PetStatusCustomers",
                c => new
                    {
                        PetStatus_PetStatusId = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PetStatus_PetStatusId, t.Customer_CustomerId })
                .ForeignKey("dbo.PetStatus", t => t.PetStatus_PetStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.PetStatus_PetStatusId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.IconAnimals",
                c => new
                    {
                        Icon_IconId = c.Int(nullable: false),
                        Animal_AnimalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Icon_IconId, t.Animal_AnimalId })
                .ForeignKey("dbo.Icons", t => t.Icon_IconId, cascadeDelete: true)
                .ForeignKey("dbo.Animals", t => t.Animal_AnimalId, cascadeDelete: true)
                .Index(t => t.Icon_IconId)
                .Index(t => t.Animal_AnimalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IconAnimals", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.IconAnimals", "Icon_IconId", "dbo.Icons");
            DropForeignKey("dbo.PetStatusCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.PetStatusCustomers", "PetStatus_PetStatusId", "dbo.PetStatus");
            DropForeignKey("dbo.PetStatusAnimals", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.PetStatusAnimals", "PetStatus_PetStatusId", "dbo.PetStatus");
            DropForeignKey("dbo.CustomerAnimals", "Animal_AnimalId", "dbo.Animals");
            DropForeignKey("dbo.CustomerAnimals", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Breeds", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Animals", "BreedId", "dbo.Breeds");
            DropIndex("dbo.IconAnimals", new[] { "Animal_AnimalId" });
            DropIndex("dbo.IconAnimals", new[] { "Icon_IconId" });
            DropIndex("dbo.PetStatusCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.PetStatusCustomers", new[] { "PetStatus_PetStatusId" });
            DropIndex("dbo.PetStatusAnimals", new[] { "Animal_AnimalId" });
            DropIndex("dbo.PetStatusAnimals", new[] { "PetStatus_PetStatusId" });
            DropIndex("dbo.CustomerAnimals", new[] { "Animal_AnimalId" });
            DropIndex("dbo.CustomerAnimals", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Breeds", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "BreedId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropTable("dbo.IconAnimals");
            DropTable("dbo.PetStatusCustomers");
            DropTable("dbo.PetStatusAnimals");
            DropTable("dbo.CustomerAnimals");
            DropTable("dbo.Icons");
            DropTable("dbo.PetStatus");
            DropTable("dbo.Customers");
            DropTable("dbo.Species");
            DropTable("dbo.Breeds");
            DropTable("dbo.Animals");
        }
    }
}
