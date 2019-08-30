namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _33 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmailItems", "Email", c => c.String(maxLength: 255));
        }

        public override void Down()
        {
            AlterColumn("dbo.EmailItems", "Email", c => c.String(maxLength: 50));
        }
    }
}
