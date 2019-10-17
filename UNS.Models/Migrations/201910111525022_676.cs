namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _676 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuD", "ID", "dbo.InstallationPlaceBuilding");
            DropForeignKey("dbo.DuD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceBuilding");
            DropForeignKey("dbo.DuUD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ContentObject_ConstractionElementID", "dbo.ConstractionElements");
            DropIndex("dbo.DuD", new[] { "ID" });
            DropIndex("dbo.DuD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "ContentHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ContentObject_ConstractionElementID" });
            DropTable("dbo.DuD");
            DropTable("dbo.DuUD");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentHouse_ConstractionElementID = c.Guid(),
                        ContentObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentHouse_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.DuUD", "ContentObject_ConstractionElementID");
            CreateIndex("dbo.DuUD", "ContentHouse_ConstractionElementID");
            CreateIndex("dbo.DuUD", "ID");
            CreateIndex("dbo.DuD", "ContentHouse_ConstractionElementID");
            CreateIndex("dbo.DuD", "ID");
            AddForeignKey("dbo.DuUD", "ContentObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "ID", "dbo.InstallationPlaceBuilding", "ID");
            AddForeignKey("dbo.DuD", "ContentHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuD", "ID", "dbo.InstallationPlaceBuilding", "ID");
        }
    }
}
