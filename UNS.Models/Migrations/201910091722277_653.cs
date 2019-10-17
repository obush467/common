namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _653 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("fias.AddressBases", "Status_ID", "fias.AddressStatuses");
            RenameColumn(table: "fias.AddressBases", name: "Status_ID", newName: "RootStatus_AddressStatusID");
            RenameIndex(table: "fias.AddressBases", name: "IX_Status_ID", newName: "IX_RootStatus_AddressStatusID");
            //DropPrimaryKey("fias.AddressStatuses");
            CreateTable(
                "fias.AddressStatuses1",
                c => new
                    {
                        AddressStatus1ID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressStatus1ID)
                .ForeignKey("fias.AddressBases", t => t.AddressStatus1ID)
                .Index(t => t.AddressStatus1ID);
            
            AddColumn("fias.AddressStatuses", "AddressStatusID", c => c.Guid(nullable: false));
            //AddPrimaryKey("fias.AddressStatuses", "AddressStatusID");
            //CreateIndex("fias.AddressStatuses", "AddressStatusID");
            //AddForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases", "ID");
            //AddForeignKey("fias.AddressBases", "RootStatus_AddressStatusID", "fias.AddressStatuses", "AddressStatusID");
            //DropColumn("fias.AddressStatuses", "ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressStatuses", "ID", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("fias.AddressBases", "RootStatus_AddressStatusID", "fias.AddressStatuses");
            DropForeignKey("fias.AddressStatuses1", "AddressStatus1ID", "fias.AddressBases");
            DropForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases");
            DropIndex("fias.AddressStatuses1", new[] { "AddressStatus1ID" });
            DropIndex("fias.AddressStatuses", new[] { "AddressStatusID" });
            DropPrimaryKey("fias.AddressStatuses");
            DropColumn("fias.AddressStatuses", "AddressStatusID");
            DropTable("fias.AddressStatuses1");
            AddPrimaryKey("fias.AddressStatuses", "ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_RootStatus_AddressStatusID", newName: "IX_Status_ID");
            RenameColumn(table: "fias.AddressBases", name: "RootStatus_AddressStatusID", newName: "Status_ID");
            AddForeignKey("fias.AddressBases", "Status_ID", "fias.AddressStatuses", "ID");
        }
    }
}
