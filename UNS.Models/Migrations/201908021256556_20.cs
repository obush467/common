namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "GeoData", c => c.Geography());
        }

        public override void Down()
        {
            DropColumn("dbo.Organizations", "GeoData");
        }
    }
}
