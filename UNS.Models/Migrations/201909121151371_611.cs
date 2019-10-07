namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _611 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.integraDU", "Done_to_installation", c => c.DateTime());
        }

        public override void Down()
        {
            AlterColumn("dbo.integraDU", "Done_to_installation", c => c.DateTime(nullable: false));
        }
    }
}
