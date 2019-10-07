namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _621 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstallationPlace",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        RegistrationNumber = c.String(),
                        InstallationPlaceType = c.String(),
                        Location_LocationID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("address.Location", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.ConstractionElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        ContentText = c.String(),
                        ContentImage = c.Binary(),
                        PermanentContent = c.Boolean(),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        SurfaceArea = c.Single(nullable: false),
                        MaxPower = c.Single(),
                        MaxBrightness = c.Single(),
                        MinPower = c.Single(),
                        MinBrightness = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
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
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressHouse_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressHouse_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressHouse_ConstractionElementID);
            
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuUD", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DU_K_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuLB_UD", t => t.ID)
                .Index(t => t.ID);
            
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
                        U_ContentText2 = c.String(),
                        U_ContentImage2 = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD");
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropIndex("dbo.DuS", new[] { "ID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.DU_K_UD", new[] { "ID" });
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationID" });
            DropTable("dbo.DuS");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.DU_K_UD");
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuU");
            DropTable("dbo.ConstractionElements");
            DropTable("dbo.InstallationPlace");
        }
    }
}
