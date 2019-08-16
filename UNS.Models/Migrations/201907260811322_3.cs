namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organization_House", "Comments", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Organization_House", "Comments");
        }
    }
}
