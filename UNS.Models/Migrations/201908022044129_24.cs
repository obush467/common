namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _24 : DbMigration
    {
        public override void Up()
        {
            // DropForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations");
            //AddForeignKey("dbo.OwnerRawAddress55", "Organization_Id", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress55", "Organization_Id", "dbo.Organizations");
            AddForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
