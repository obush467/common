namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _637 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.AddressCached",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        AddressGUID = c.Guid(nullable: false),
                        AddressPARENTGUID = c.Guid(nullable: false),
                        ItemAddress = c.String(nullable: false),
                        FullAddress = c.String(nullable: false),
                        ItemCategory = c.String(nullable: false),
                        ItemType = c.String(nullable: false),
                        STARTDATE = c.DateTime(nullable: false),
                        ENDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropTable("address.AddressCached");
        }
    }
}
