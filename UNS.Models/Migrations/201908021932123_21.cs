namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.RawAddress", "TypeOwner", c => c.String(maxLength: 50));
           // AddColumn("dbo.RawAddress", "Source", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RawAddress", "Source");
            DropColumn("dbo.RawAddress", "TypeOwner");
        }
    }
}
