namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _661 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressCachedFull",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        GeoData = c.Geography(),
                        AdmAreaId = c.Guid(),
                        KLADR = c.String(maxLength: 50),
                        UNOM = c.Int(),
                        ADR_TYPE = c.String(maxLength: 50),
                        StoreysCount = c.Int(),
                        WallMaterial = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        Class = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        Attribute = c.String(maxLength: 50),
                        TotalArea = c.Double(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("address.AddressCached", t => t.AddressID)
                .ForeignKey("address.AdmArea", t => t.AdmAreaId)
                .Index(t => t.AddressID, name: "FullAddressIndex")
                .Index(t => t.AdmAreaId);
            
            AlterColumn("address.AddressCached", "ItemAddress", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("address.AddressCached", "FullAddress", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("address.AddressCached", "ItemCategory", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("address.AddressCached", "ItemType", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("address.AddressCached", new[] { "AddressID", "FullAddress", "AddressGUID", "AddressPARENTGUID", "ItemAddress", "STARTDATE", "ENDDATE" }, name: "FullAddressIndex");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressCachedFull", "AdmAreaId", "address.AdmArea");
            DropForeignKey("dbo.AddressCachedFull", "AddressID", "address.AddressCached");
            DropIndex("dbo.AddressCachedFull", new[] { "AdmAreaId" });
            DropIndex("dbo.AddressCachedFull", "FullAddressIndex");
            DropIndex("address.AddressCached", "FullAddressIndex");
            AlterColumn("address.AddressCached", "ItemType", c => c.String(nullable: false));
            AlterColumn("address.AddressCached", "ItemCategory", c => c.String(nullable: false));
            AlterColumn("address.AddressCached", "FullAddress", c => c.String(nullable: false));
            AlterColumn("address.AddressCached", "ItemAddress", c => c.String(nullable: false));
            DropTable("dbo.AddressCachedFull");
        }
    }
}
