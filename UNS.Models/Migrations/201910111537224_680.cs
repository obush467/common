namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _680 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuD", "ID", "dbo.InstallationPlaceBuilding");
            DropIndex("dbo.DuD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuD", new[] { "ID" });
            DropTable("dbo.DuD");
        }
    }
}
