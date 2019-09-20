namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _604 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressCodes", "AddressBase_ID", "fias.AddressBases");
            DropForeignKey("fias.AddressBases", "AddressCode_AddressBase_ID", "fias.AddressCodes");
            DropIndex("fias.AddressCodes", new[] { "AddressBase_ID" });
            RenameColumn(table: "fias.AddressBases", name: "AddressCode_AddressBase_ID", newName: "AddressCode_AddressCode_ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_AddressCode_AddressBase_ID", newName: "IX_AddressCode_AddressCode_ID");
            DropPrimaryKey("fias.AddressCodes");
            AddColumn("fias.AddressCodes", "AddressCode_ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("fias.AddressCodes", "AddressCode_ID");
            CreateIndex("fias.AddressCodes", "AddressCode_ID");
            AddForeignKey("fias.AddressCodes", "AddressCode_ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "fias.AddressCodes", "AddressCode_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "fias.AddressCodes");
            DropForeignKey("fias.AddressCodes", "AddressCode_ID", "fias.AddressBases");
            DropIndex("fias.AddressCodes", new[] { "AddressCode_ID" });
            DropPrimaryKey("fias.AddressCodes");
            DropColumn("fias.AddressCodes", "AddressCode_ID");
            AddPrimaryKey("fias.AddressCodes", "AddressBase_ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_AddressCode_AddressCode_ID", newName: "IX_AddressCode_AddressBase_ID");
            RenameColumn(table: "fias.AddressBases", name: "AddressCode_AddressCode_ID", newName: "AddressCode_AddressBase_ID");
            CreateIndex("fias.AddressCodes", "AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressCode_AddressBase_ID", "fias.AddressCodes", "AddressBase_ID");
            AddForeignKey("fias.AddressCodes", "AddressBase_ID", "fias.AddressBases", "ID");
        }
    }
}
