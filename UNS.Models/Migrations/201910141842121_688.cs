namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _688 : DbMigration
    {
        public override void Up()
        {
            DropIndex("address.AddressCached", "FullAddressIndex");
            AlterColumn("address.AddressCached", "STARTDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("address.AddressCached", "ENDDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            CreateIndex("address.AddressCached", new[] { "AddressID", "FullAddress", "AddressGUID", "AddressPARENTGUID", "ItemAddress", "STARTDATE", "ENDDATE" }, name: "FullAddressIndex");
        }
        
        public override void Down()
        {
            DropIndex("address.AddressCached", "FullAddressIndex");
            AlterColumn("address.AddressCached", "ENDDATE", c => c.DateTime(nullable: false));
            AlterColumn("address.AddressCached", "STARTDATE", c => c.DateTime(nullable: false));
            CreateIndex("address.AddressCached", new[] { "AddressID", "FullAddress", "AddressGUID", "AddressPARENTGUID", "ItemAddress", "STARTDATE", "ENDDATE" }, name: "FullAddressIndex");
        }
    }
}
