namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _666 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstallationPlace",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        InstallationPlaceType = c.String(),
                        TS = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Location_LocationBaseID = c.Guid(nullable: false),
                        TechProject_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("address.LocationBase", t => t.Location_LocationBaseID, cascadeDelete: true)
                .ForeignKey("dbo.TechProjects", t => t.TechProject_Id)
                .Index(t => t.Location_LocationBaseID)
                .Index(t => t.TechProject_Id);
            
            CreateTable(
                "dbo.ConstractionElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false, identity: true),
                        ContentText = c.String(),
                        ContentImage = c.Binary(),
                        PermanentContent = c.Boolean(),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        SurfaceArea = c.Single(nullable: false),
                        ContentText2 = c.String(),
                        ContentImage2 = c.Binary(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConstractionElementID);
            
            CreateTable(
                "dbo.InstallationPlaceDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceDU", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            CreateTable(
                "dbo.LightBoxElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        MaxPower = c.Single(nullable: false),
                        MaxBrightness = c.Single(nullable: false),
                        MinPower = c.Single(nullable: false),
                        MinBrightness = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ConstractionElementID)
                .ForeignKey("dbo.ConstractionElements", t => t.ConstractionElementID)
                .Index(t => t.ConstractionElementID);
            
            CreateTable(
                "dbo.LightBoxTwoFieldElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        MaxPower = c.Single(nullable: false),
                        MaxBrightness = c.Single(nullable: false),
                        MinPower = c.Single(nullable: false),
                        MinBrightness = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ConstractionElementID)
                .ForeignKey("dbo.ConstractionElements", t => t.ConstractionElementID)
                .Index(t => t.ConstractionElementID);
            
            CreateTable(
                "dbo.DuLB_U",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_S",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuS", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressHouse_ConstractionElementID = c.Guid(),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceDU", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressHouse_ConstractionElementID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressHouse_ConstractionElementID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuUD", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DuUD", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceDU");
            DropForeignKey("dbo.DuLB_S", "ID", "dbo.DuS");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceDU");
            DropForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.InstallationPlace", "TechProject_Id", "dbo.TechProjects");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationBaseID", "address.LocationBase");
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuLB_S", new[] { "ID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.InstallationPlaceDU", new[] { "ID" });
            DropIndex("dbo.InstallationPlace", new[] { "TechProject_Id" });
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationBaseID" });
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuLB_S");
            DropTable("dbo.DuS");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.LightBoxTwoFieldElements");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.DuU");
            DropTable("dbo.InstallationPlaceDU");
            DropTable("dbo.ConstractionElements");
            DropTable("dbo.InstallationPlace");
        }
    }
}
