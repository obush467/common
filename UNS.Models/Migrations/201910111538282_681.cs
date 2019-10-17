namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _681 : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.DuUD", new[] { "ContentObject_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropTable("dbo.DuUD");
        }
    }
}
