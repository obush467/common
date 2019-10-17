namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _657 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressCodes", "AddressCodeID", "fias.AddressBases");
            DropForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases");
            AddForeignKey("fias.AddressCodes", "AddressCodeID", "fias.AddressBases", "ID", cascadeDelete: true);
            AddForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases");
            DropForeignKey("fias.AddressCodes", "AddressCodeID", "fias.AddressBases");
            AddForeignKey("fias.AddressStatuses", "AddressStatusID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressCodes", "AddressCodeID", "fias.AddressBases", "ID");
        }
    }
}
