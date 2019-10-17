namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _656 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressStatuses1", "AddressStatus1ID", "fias.AddressBases");
            DropIndex("fias.AddressStatuses1", new[] { "AddressStatus1ID" });
            CreateTable(
                "fias.AddressStatuses",
                c => new
                    {
                        AddressStatusID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressStatusID)
                .ForeignKey("fias.AddressBases", t => t.AddressStatusID)
                .Index(t => t.AddressStatusID);
            
            DropTable("fias.AddressStatuses1");
        }
        
        public override void Down()
        {
            CreateTable(
                "fias.AddressStatuses1",
                c => new
                    {
                        AddressStatus1ID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressStatus1ID);
            
            DropForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases");
            DropIndex("fias.AddressStatuses", new[] { "AddressStatusID" });
            DropTable("fias.AddressStatuses");
            CreateIndex("fias.AddressStatuses1", "AddressStatus1ID");
            AddForeignKey("fias.AddressStatuses1", "AddressStatus1ID", "fias.AddressBases", "ID");
        }
    }
}
