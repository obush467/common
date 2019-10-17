namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _694 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.UNOM_Items",
                c => new
                    {
                        UNOM_ItemID = c.Guid(nullable: false, identity: true),
                        GeoData = c.Geography(),
                        AdmAreaId = c.Guid(),
                        UNOM = c.Int(nullable: false),
                        AddressCachedObject_AddressID = c.Guid(),
                    })
                .PrimaryKey(t => t.UNOM_ItemID)
                .ForeignKey("address.AdmArea", t => t.AdmAreaId)
                .ForeignKey("address.AddressCachedObject", t => t.AddressCachedObject_AddressID)
                .Index(t => t.AdmAreaId)
                .Index(t => t.AddressCachedObject_AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.UNOM_Items", "AddressCachedObject_AddressID", "address.AddressCachedObject");
            DropForeignKey("address.UNOM_Items", "AdmAreaId", "address.AdmArea");
            DropIndex("address.UNOM_Items", new[] { "AddressCachedObject_AddressID" });
            DropIndex("address.UNOM_Items", new[] { "AdmAreaId" });
            DropTable("address.UNOM_Items");
        }
    }
}
