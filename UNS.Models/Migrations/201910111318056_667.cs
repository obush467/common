namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _667 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceDU");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuLB_S", "ID", "dbo.DuS");
            DropForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceDU");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropIndex("dbo.InstallationPlaceDU", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            DropIndex("dbo.DuLB_S", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropTable("dbo.ConstractionElements");
            DropTable("dbo.InstallationPlaceDU");
            DropTable("dbo.DuU");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.LightBoxTwoFieldElements");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.DuS");
            DropTable("dbo.DuLB_S");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuLB_UD");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressHouse_ConstractionElementID = c.Guid(),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_S",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_U",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ConstractionElementID);
            
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
                .PrimaryKey(t => t.ConstractionElementID);
            
            CreateTable(
                "dbo.DuU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InstallationPlaceDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
            CreateIndex("dbo.DuLB_UD", "ID");
            CreateIndex("dbo.DuUD", "AddressObject_ConstractionElementID");
            CreateIndex("dbo.DuUD", "AddressHouse_ConstractionElementID");
            CreateIndex("dbo.DuUD", "ID");
            CreateIndex("dbo.DuLB_S", "ID");
            CreateIndex("dbo.DuS", "ID");
            CreateIndex("dbo.DuLB_U", "ID");
            CreateIndex("dbo.LightBoxTwoFieldElements", "ConstractionElementID");
            CreateIndex("dbo.LightBoxElements", "ConstractionElementID");
            CreateIndex("dbo.DuU", "AddressObject_ConstractionElementID");
            CreateIndex("dbo.DuU", "ID");
            CreateIndex("dbo.InstallationPlaceDU", "ID");
            AddForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD", "ID");
            AddForeignKey("dbo.DuUD", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceDU", "ID");
            AddForeignKey("dbo.DuLB_S", "ID", "dbo.DuS", "ID");
            AddForeignKey("dbo.DuS", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DuLB_U", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceDU", "ID");
            AddForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace", "ID");
        }
    }
}
