namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _687 : DbMigration
    {
        public override void Up()
        {
            DropIndex("address.AddressCached", "FullAddressIndex");
            AddColumn("address.AddressCached", "REGIONCODE", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("address.AddressCached", "AddressPARENTGUID", c => c.Guid());
            CreateIndex("address.AddressCached", new[] { "AddressID", "FullAddress", "AddressGUID", "AddressPARENTGUID", "ItemAddress", "STARTDATE", "ENDDATE" }, name: "FullAddressIndex");
        }
        
        public override void Down()
        {
            DropIndex("address.AddressCached", "FullAddressIndex");
            AlterColumn("address.AddressCached", "AddressPARENTGUID", c => c.Guid(nullable: false));
            DropColumn("address.AddressCached", "REGIONCODE");
            CreateIndex("address.AddressCached", new[] { "AddressID", "FullAddress", "AddressGUID", "AddressPARENTGUID", "ItemAddress", "STARTDATE", "ENDDATE" }, name: "FullAddressIndex");
        }
    }
}
