namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _642 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AddressCacheds");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddressCacheds",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        AddressGUID = c.Guid(nullable: false),
                        AddressPARENTGUID = c.Guid(nullable: false),
                        ItemAddress = c.String(),
                        FullAddress = c.String(),
                        ItemCategory = c.String(),
                        ItemType = c.String(),
                        STARTDATE = c.DateTime(nullable: false),
                        ENDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
        }
    }
}
