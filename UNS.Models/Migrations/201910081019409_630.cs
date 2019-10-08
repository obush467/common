namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _630 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases");
            DropIndex("fias.AddressBases", new[] { "AddressBase_ID" });
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "PREVID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "NEXTID", newName: "PREVID");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "__mig_tmp__0", newName: "NEXTID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_PREVID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_NEXTID", newName: "IX_PREVID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "__mig_tmp__0", newName: "IX_NEXTID");
            DropColumn("fias.AddressBases", "AddressBase_ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "AddressBase_ID", c => c.Guid());
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_NEXTID", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "IX_PREVID", newName: "IX_NEXTID");
            RenameIndex(table: "dbo.AddressBase_PrevNext", name: "__mig_tmp__0", newName: "IX_PREVID");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "NEXTID", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "PREVID", newName: "NEXTID");
            RenameColumn(table: "dbo.AddressBase_PrevNext", name: "__mig_tmp__0", newName: "PREVID");
            CreateIndex("fias.AddressBases", "AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases", "ID");
        }
    }
}
