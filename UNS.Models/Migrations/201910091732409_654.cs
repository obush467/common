namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _654 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressBases", "RootStatus_AddressStatusID", "fias.AddressStatuses");
            DropIndex("fias.AddressBases", new[] { "RootStatus_AddressStatusID" });
            DropColumn("fias.AddressBases", "RootStatus_AddressStatusID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "RootStatus_AddressStatusID", c => c.Guid());
            CreateIndex("fias.AddressBases", "RootStatus_AddressStatusID");
            AddForeignKey("fias.AddressBases", "RootStatus_AddressStatusID", "fias.AddressStatuses", "AddressStatusID");
        }
    }
}
