namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _620 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.Location",
                c => new
                    {
                        LocationID = c.Guid(nullable: false),
                        WGS84 = c.Geography(),
                        EGKO = c.Geometry(),
                        MGGT = c.Geometry(),
                        Address_ID = c.Guid(),
                        AdmArea_AdmAreaId = c.Guid(),
                    })
                .PrimaryKey(t => t.LocationID)
                .ForeignKey("fias.AddressBases", t => t.Address_ID)
                .ForeignKey("address.AdmArea", t => t.AdmArea_AdmAreaId)
                .Index(t => t.Address_ID)
                .Index(t => t.AdmArea_AdmAreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.Location", "AdmArea_AdmAreaId", "address.AdmArea");
            DropForeignKey("address.Location", "Address_ID", "fias.AddressBases");
            DropIndex("address.Location", new[] { "AdmArea_AdmAreaId" });
            DropIndex("address.Location", new[] { "Address_ID" });
            DropTable("address.Location");
        }
    }
}
