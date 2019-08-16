namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FaxItems", "Fax", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.FaxItems", "Fax");
        }
    }
}
