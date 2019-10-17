namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _673 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.InstallationPlace", "TS", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InstallationPlace", "TS", c => c.Binary());
        }
    }
}
