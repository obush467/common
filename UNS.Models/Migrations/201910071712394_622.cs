namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _622 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropPrimaryKey("dbo.InstallationPlace");
            DropPrimaryKey("dbo.ConstractionElements");
            AlterColumn("dbo.InstallationPlace", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.ConstractionElements", "ConstractionElementID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.InstallationPlace", "ID");
            AddPrimaryKey("dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace", "ID");
            AddForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropPrimaryKey("dbo.ConstractionElements");
            DropPrimaryKey("dbo.InstallationPlace");
            AlterColumn("dbo.ConstractionElements", "ConstractionElementID", c => c.Guid(nullable: false));
            AlterColumn("dbo.InstallationPlace", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ConstractionElements", "ConstractionElementID");
            AddPrimaryKey("dbo.InstallationPlace", "ID");
            AddForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace", "ID");
        }
    }
}
