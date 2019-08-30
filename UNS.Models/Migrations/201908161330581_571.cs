namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _571 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");

        }

        public override void Down()
        {
        }
    }
}
