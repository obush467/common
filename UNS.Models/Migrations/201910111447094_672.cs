namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _672 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.InstallationPlace", "TS", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InstallationPlace", "TS", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
