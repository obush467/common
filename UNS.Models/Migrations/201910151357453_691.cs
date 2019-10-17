namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _691 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.AddressCachedObject",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        GeoData = c.Geography(),
                        AdmAreaId = c.Guid(),
                        UNOM = c.Int(),
                        CADNUM = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("address.AddressCached", t => t.AddressID)
                .ForeignKey("address.AdmArea", t => t.AdmAreaId)
                .Index(t => t.AddressID, name: "FullAddressIndex")
                .Index(t => t.AdmAreaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.AddressCachedObject", "AdmAreaId", "address.AdmArea");
            DropForeignKey("address.AddressCachedObject", "AddressID", "address.AddressCached");
            DropIndex("address.AddressCachedObject", new[] { "AdmAreaId" });
            DropIndex("address.AddressCachedObject", "FullAddressIndex");
            DropTable("address.AddressCachedObject");
        }
    }
}
