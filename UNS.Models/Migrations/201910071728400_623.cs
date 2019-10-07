namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _623 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropPrimaryKey("address.Location");
            AlterColumn("address.Location", "LocationID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("address.Location", "LocationID");
            AddForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location", "LocationID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropPrimaryKey("address.Location");
            AlterColumn("address.Location", "LocationID", c => c.Guid(nullable: false));
            AddPrimaryKey("address.Location", "LocationID");
            AddForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location", "LocationID");
        }
    }
}
