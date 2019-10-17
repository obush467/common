namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _692 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.AddressCachedObjectBuilding",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        StoreysCount = c.Int(),
                        WallMaterial = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        Class = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        Attribute = c.String(maxLength: 50),
                        TotalArea = c.Double(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("address.AddressCachedObject", t => t.AddressID)
                .Index(t => t.AddressID, name: "FullAddressIndex");
            
            CreateTable(
                "address.AddressCachedObjectStead",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("address.AddressCachedObject", t => t.AddressID)
                .Index(t => t.AddressID, name: "FullAddressIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.AddressCachedObjectStead", "AddressID", "address.AddressCachedObject");
            DropForeignKey("address.AddressCachedObjectBuilding", "AddressID", "address.AddressCachedObject");
            DropIndex("address.AddressCachedObjectStead", "FullAddressIndex");
            DropIndex("address.AddressCachedObjectBuilding", "FullAddressIndex");
            DropTable("address.AddressCachedObjectStead");
            DropTable("address.AddressCachedObjectBuilding");
        }
    }
}
