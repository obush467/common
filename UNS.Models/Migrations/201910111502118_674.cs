namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _674 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace");
            DropIndex("dbo.InstallationPlaceDU", new[] { "ID" });
            CreateTable(
                "dbo.InstallationPlaceBuilding",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .Index(t => t.ID);            
            DropTable("dbo.InstallationPlaceDU");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InstallationPlaceDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.InstallationPlaceBuilding", "ID", "dbo.InstallationPlace");
            DropIndex("dbo.InstallationPlaceBuilding", new[] { "ID" });
            DropTable("dbo.InstallationPlaceBuilding");
            CreateIndex("dbo.InstallationPlaceDU", "ID");
            AddForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace", "ID");
        }
    }
}
