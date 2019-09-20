namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _593 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("fias.Room", "HOUSEGUID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
           // AlterColumn("fias.Room", "HOUSEGUID", c => c.Guid());
        }
    }
}
