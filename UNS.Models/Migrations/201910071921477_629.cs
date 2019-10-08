namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _629 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddressBaseAddressBases", newName: "AddressBase_PrevNext");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "AddressBase_ID", newName: "PREVID");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "AddressBase_ID1", newName: "NEXTID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_AddressBase_ID", newName: "IX_PREVID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_AddressBase_ID1", newName: "IX_NEXTID");
            AddColumn("fias.AddressBases", "AddressBase_ID", c => c.Guid());
            CreateIndex("fias.AddressBases", "AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases");
            DropIndex("fias.AddressBases", new[] { "AddressBase_ID" });
            DropColumn("fias.AddressBases", "AddressBase_ID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_NEXTID", newName: "IX_AddressBase_ID1");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_PREVID", newName: "IX_AddressBase_ID");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "NEXTID", newName: "AddressBase_ID1");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "PREVID", newName: "AddressBase_ID");
            RenameTable(name: "dbo.AddressBase_PrevNext", newName: "AddressBaseAddressBases");
        }
    }
}
