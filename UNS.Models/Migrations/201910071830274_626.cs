namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _626 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddressBase_PrevNext", newName: "AddressBaseAddressBases");
            DropForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases");
            DropIndex("fias.AddressBases", new[] { "AddressBase_ID" });
            RenameColumn(table: "dbo.AddressBaseAddressBases", name: "PREVID", newName: "AddressBase_ID");
            RenameColumn(table: "dbo.AddressBaseAddressBases", name: "NEXTID", newName: "AddressBase_ID1");
            RenameIndex(table: "dbo.AddressBaseAddressBases", name: "IX_PREVID", newName: "IX_AddressBase_ID");
            RenameIndex(table: "dbo.AddressBaseAddressBases", name: "IX_NEXTID", newName: "IX_AddressBase_ID1");
            DropColumn("fias.AddressBases", "AddressBase_ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "AddressBase_ID", c => c.Guid());
            RenameIndex(table: "dbo.AddressBaseAddressBases", name: "IX_AddressBase_ID1", newName: "IX_NEXTID");
            RenameIndex(table: "dbo.AddressBaseAddressBases", name: "IX_AddressBase_ID", newName: "IX_PREVID");
            RenameColumn(table: "dbo.AddressBaseAddressBases", name: "AddressBase_ID1", newName: "NEXTID");
            RenameColumn(table: "dbo.AddressBaseAddressBases", name: "AddressBase_ID", newName: "PREVID");
            CreateIndex("fias.AddressBases", "AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases", "ID");
            RenameTable(name: "dbo.AddressBaseAddressBases", newName: "AddressBase_PrevNext");
        }
    }
}
