namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _613 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.integraDU", "Done_to_installation", c => c.DateTime());
        }

        public override void Down()
        {
            DropColumn("dbo.integraDU", "Done_to_installation");
        }
    }
}
