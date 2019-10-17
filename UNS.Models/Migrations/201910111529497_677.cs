namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _677 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceBuilding");
            DropForeignKey("dbo.DuU", "ContentObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "ContentObject_ConstractionElementID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropTable("dbo.ConstractionElements");
            DropTable("dbo.DuU");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.LightBoxTwoFieldElements");
        }
        
        public override void Down()
        {
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
                        ContentObject_ConstractionElementID = c.Guid(),
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
            
            CreateIndex("dbo.LightBoxTwoFieldElements", "ConstractionElementID");
            CreateIndex("dbo.LightBoxElements", "ConstractionElementID");
            CreateIndex("dbo.DuU", "ContentObject_ConstractionElementID");
            CreateIndex("dbo.DuU", "ID");
            AddForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ContentObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceBuilding", "ID");
        }
    }
}
