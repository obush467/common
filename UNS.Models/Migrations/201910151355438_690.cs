namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _690 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddressCachedFull", "AddressID", "address.AddressCached");
            DropForeignKey("dbo.AddressCachedFull", "AdmAreaId", "address.AdmArea");
            DropIndex("dbo.AddressCachedFull", "FullAddressIndex");
            DropIndex("dbo.AddressCachedFull", new[] { "AdmAreaId" });
            DropColumn("address.AddressCached", "StoreysCount");
            DropColumn("address.AddressCached", "WallMaterial");
            DropColumn("address.AddressCached", "Purpose");
            DropColumn("address.AddressCached", "Class");
            DropColumn("address.AddressCached", "Type");
            DropColumn("address.AddressCached", "Attribute");
            DropColumn("address.AddressCached", "TotalArea");
            DropColumn("address.AddressCached", "Discriminator");
            //DropTable("dbo.AddressCachedFull");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddressCachedFull",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        GeoData = c.Geography(),
                        AdmAreaId = c.Guid(),
                        UNOM = c.Int(),
                        CADNUM = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressID);
            
            AddColumn("address.AddressCached", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("address.AddressCached", "TotalArea", c => c.Double());
            AddColumn("address.AddressCached", "Attribute", c => c.String(maxLength: 50));
            AddColumn("address.AddressCached", "Type", c => c.String(maxLength: 50));
            AddColumn("address.AddressCached", "Class", c => c.String(maxLength: 50));
            AddColumn("address.AddressCached", "Purpose", c => c.String(maxLength: 50));
            AddColumn("address.AddressCached", "WallMaterial", c => c.String(maxLength: 50));
            AddColumn("address.AddressCached", "StoreysCount", c => c.Int());
            CreateIndex("dbo.AddressCachedFull", "AdmAreaId");
            CreateIndex("dbo.AddressCachedFull", "AddressID", name: "FullAddressIndex");
            AddForeignKey("dbo.AddressCachedFull", "AdmAreaId", "address.AdmArea", "AdmAreaId");
            AddForeignKey("dbo.AddressCachedFull", "AddressID", "address.AddressCached", "AddressID");
        }
    }
}
