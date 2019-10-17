namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _678 : DbMigration
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
                        ContentObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlaceBuilding", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.ContentObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.ContentObject_ConstractionElementID);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ContentObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlaceBuilding");
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ContentObject_ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropTable("dbo.LightBoxTwoFieldElements");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.DuU");
            DropTable("dbo.ConstractionElements");
        }
    }
}
