namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _29 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_ID" });
            CreateIndex("dbo.OwnerRawAddress", "Organization_Id");
        }

        public override void Down()
        {
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_Id" });
            CreateIndex("dbo.OwnerRawAddress", "Organization_ID");
        }
    }
}
