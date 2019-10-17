namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _662 : DbMigration
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
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuLB_S");
            DropTable("dbo.DuS");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.LightBoxTwoFieldElements");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.DuU");
            DropTable("dbo.ConstractionElements");
        }
    }
}
