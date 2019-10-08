namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _631 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AddressCodes", newSchema: "fias");
            DropForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "dbo.AddressCodes");
            RenameColumn(table: "fias.AddressBases", name: "AddressCode_AddressCode_ID", newName: "AddressCode_ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_AddressCode_AddressCode_ID", newName: "IX_AddressCode_ID");
            DropPrimaryKey("fias.AddressCodes");
            AddColumn("fias.AddressCodes", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("fias.AddressCodes", "ID");
            AddForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes", "ID");
            DropColumn("fias.AddressCodes", "AddressCode_ID");
            DropColumn("fias.AddressCodes", "AddressBase_ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressCodes", "AddressBase_ID", c => c.Guid(nullable: false));
            AddColumn("fias.AddressCodes", "AddressCode_ID", c => c.Guid(nullable: false));
            DropForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes");
            DropPrimaryKey("fias.AddressCodes");
            DropColumn("fias.AddressCodes", "ID");
            AddPrimaryKey("fias.AddressCodes", "AddressCode_ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_AddressCode_ID", newName: "IX_AddressCode_AddressCode_ID");
            RenameColumn(table: "fias.AddressBases", name: "AddressCode_ID", newName: "AddressCode_AddressCode_ID");
            AddForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "dbo.AddressCodes", "AddressCode_ID");
            MoveTable(name: "fias.AddressCodes", newSchema: "dbo");
        }
    }
}
