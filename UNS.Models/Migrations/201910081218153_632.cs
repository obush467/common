namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _632 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressStatus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("fias.AddressBases", "AddressStatus_ID", c => c.Guid());
            CreateIndex("fias.AddressBases", "AddressStatus_ID");
            AddForeignKey("fias.AddressBases", "AddressStatus_ID", "dbo.AddressStatus", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressBases", "AddressStatus_ID", "dbo.AddressStatus");
            DropIndex("fias.AddressBases", new[] { "AddressStatus_ID" });
            DropColumn("fias.AddressBases", "AddressStatus_ID");
            DropTable("dbo.AddressStatus");
        }
    }
}
