namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _573 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Comments", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Organizations", "Comments");
        }
    }
}
