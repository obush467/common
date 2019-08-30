namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _28 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OwnerRawAddress55", "ID", "dbo.RawAddress");
            DropForeignKey("dbo.OwnerRawAddress55", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.OwnerRawAddress55", new[] { "ID" });
            DropIndex("dbo.OwnerRawAddress55", new[] { "Organization_Id" });
            AddForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations", "Id", cascadeDelete: false);
            DropTable("dbo.OwnerRawAddress55");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.OwnerRawAddress55",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    Organization_Id = c.Guid(),
                })
                .PrimaryKey(t => t.ID);

            DropForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations");
            CreateIndex("dbo.OwnerRawAddress55", "Organization_Id");
            CreateIndex("dbo.OwnerRawAddress55", "ID");
            AddForeignKey("dbo.OwnerRawAddress55", "Organization_Id", "dbo.Organizations", "Id");
            AddForeignKey("dbo.OwnerRawAddress55", "ID", "dbo.RawAddress", "ID");
        }
    }
}
