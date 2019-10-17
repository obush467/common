namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _695 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "address.UNOM_Items", newName: "AddressCachedObject_UNOM");
            DropColumn("address.AddressCachedObject", "UNOM");
        }
        
        public override void Down()
        {
            AddColumn("address.AddressCachedObject", "UNOM", c => c.Int());
            RenameTable(name: "address.AddressCachedObject_UNOM", newName: "UNOM_Items");
        }
    }
}
