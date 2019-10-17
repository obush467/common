namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _652 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes");
            DropForeignKey("dbo.StudentAddresses", "StudentAddressId", "dbo.Students");
            DropIndex("fias.AddressBases", new[] { "AddressCode_ID" });
            DropIndex("fias.AddressCodes", new[] { "Address_ID" });
            RenameColumn(table: "fias.AddressCodes", name: "Address_ID", newName: "AddressCodeID");
            RenameColumn(table: "fias.AddressBases", name: "AddressStatus_ID", newName: "Status_ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_AddressStatus_ID", newName: "IX_Status_ID");
            DropPrimaryKey("fias.AddressCodes");
            AlterColumn("fias.AddressCodes", "AddressCodeID", c => c.Guid(nullable: false));
            AddPrimaryKey("fias.AddressCodes", "AddressCodeID");
            CreateIndex("fias.AddressCodes", "AddressCodeID");
            AddForeignKey("dbo.StudentAddresses", "StudentAddressId", "dbo.Students", "StudentId", cascadeDelete: true);
            DropColumn("fias.AddressBases", "AddressCode_ID");
            DropColumn("fias.AddressCodes", "ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressCodes", "ID", c => c.Guid(nullable: false));
            AddColumn("fias.AddressBases", "AddressCode_ID", c => c.Guid());
            DropForeignKey("dbo.StudentAddresses", "StudentAddressId", "dbo.Students");
            DropIndex("fias.AddressCodes", new[] { "AddressCodeID" });
            DropPrimaryKey("fias.AddressCodes");
            AlterColumn("fias.AddressCodes", "AddressCodeID", c => c.Guid());
            AddPrimaryKey("fias.AddressCodes", "ID");
            RenameIndex(table: "fias.AddressBases", name: "IX_Status_ID", newName: "IX_AddressStatus_ID");
            RenameColumn(table: "fias.AddressBases", name: "Status_ID", newName: "AddressStatus_ID");
            RenameColumn(table: "fias.AddressCodes", name: "AddressCodeID", newName: "Address_ID");
            CreateIndex("fias.AddressCodes", "Address_ID");
            CreateIndex("fias.AddressBases", "AddressCode_ID");
            AddForeignKey("dbo.StudentAddresses", "StudentAddressId", "dbo.Students", "StudentId");
            AddForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes", "ID");
        }
    }
}
