namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _34 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "WebSite", c => c.String(maxLength: 255));
        }

        public override void Down()
        {
            AlterColumn("dbo.Organizations", "WebSite", c => c.String(maxLength: 100));
        }
    }
}
