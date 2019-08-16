namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _40 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.HouseFullBTI",
                c => new
                    {
                        HouseFullBTI_ID = c.Guid(nullable: false),
                        GeoData = c.Geography(),
                        Address = c.String(maxLength: 1000),
                        UNOM = c.Int(),
                        KLADR = c.String(maxLength: 50),
                        ADR_TYPE = c.String(maxLength: 50),
                        StoreysCount = c.Int(),
                        WallMaterial = c.String(maxLength: 50),
                        Purpose = c.String(maxLength: 50),
                        Class = c.String(maxLength: 50),
                        Type = c.String(maxLength: 50),
                        Attribute = c.String(maxLength: 50),
                        TotalArea = c.Single(),
                        HouseFull_HOUSEID = c.Guid(),
                    })
                .PrimaryKey(t => t.HouseFullBTI_ID)
                .ForeignKey("address.HouseFull", t => t.HouseFull_HOUSEID)
                .Index(t => t.HouseFull_HOUSEID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.HouseFullBTI", "HouseFull_HOUSEID", "address.HouseFull");
            DropIndex("address.HouseFullBTI", new[] { "HouseFull_HOUSEID" });
            DropTable("address.HouseFullBTI");
        }
    }
}
