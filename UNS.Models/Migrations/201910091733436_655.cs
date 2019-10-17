namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _655 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases");
            DropIndex("fias.AddressStatuses", new[] { "AddressStatusID" });
            DropTable("fias.AddressStatuses");
        }
        
        public override void Down()
        {
            CreateTable(
                "fias.AddressStatuses",
                c => new
                    {
                        AddressStatusID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressStatusID);
            
            CreateIndex("fias.AddressStatuses", "AddressStatusID");
            AddForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases", "ID");
        }
    }
}
