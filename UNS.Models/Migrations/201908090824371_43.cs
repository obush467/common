namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("address.AO_Named", "OFFNAME_PREFIX_FULL", c => c.String(maxLength: 50));
            AddColumn("address.AO_Named", "OFFNAME_PREFIX_SHORT", c => c.String(maxLength: 50));
            DropColumn("address.AO_Named", "OFFNAME_PREFIX");
        }
        
        public override void Down()
        {
            AddColumn("address.AO_Named", "OFFNAME_PREFIX", c => c.String(maxLength: 20));
            DropColumn("address.AO_Named", "OFFNAME_PREFIX_SHORT");
            DropColumn("address.AO_Named", "OFFNAME_PREFIX_FULL");
        }
    }
}
