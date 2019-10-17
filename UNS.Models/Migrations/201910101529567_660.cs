namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _660 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstallationPlace",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        InstallationPlaceType = c.String(),
                        TS = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Location_LocationBaseID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("address.LocationBase", t => t.Location_LocationBaseID, cascadeDelete: true)
                .Index(t => t.Location_LocationBaseID);
            
            CreateTable(
                "dbo.InstallationPlaceDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .Index(t => t.ID);
            
            AddColumn("address.LocationBase", "TS", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            CreateIndex("address.LocationBase", "ClarificationOfLocation", name: "IX_Name");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationBaseID", "address.LocationBase");
            DropIndex("dbo.InstallationPlaceDU", new[] { "ID" });
            DropIndex("address.LocationBase", "IX_Name");
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationBaseID" });
            DropColumn("address.LocationBase", "TS");
            DropTable("dbo.InstallationPlaceDU");
            DropTable("dbo.InstallationPlace");
        }
    }
}
