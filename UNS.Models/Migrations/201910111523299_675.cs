namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _675 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.DuD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentHouse_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceBuilding", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.ContentHouse_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.ContentHouse_ConstractionElementID);
            
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
                "dbo.DuU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceBuilding", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.ContentObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.ContentObject_ConstractionElementID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentHouse_ConstractionElementID = c.Guid(),
                        ContentObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceBuilding", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.ContentHouse_ConstractionElementID)
                .ForeignKey("dbo.ConstractionElements", t => t.ContentObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.ContentHouse_ConstractionElementID)
                .Index(t => t.ContentObject_ConstractionElementID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuUD", "ContentObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceBuilding");
            DropForeignKey("dbo.DuU", "ContentObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceBuilding");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuD", "ID", "dbo.InstallationPlaceBuilding");
            DropIndex("dbo.DuUD", new[] { "ContentObject_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "ContentObject_ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.DuD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuD", new[] { "ID" });
            DropTable("dbo.DuUD");
            DropTable("dbo.DuU");
            DropTable("dbo.LightBoxTwoFieldElements");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.DuD");
            DropTable("dbo.ConstractionElements");
        }
    }
}
