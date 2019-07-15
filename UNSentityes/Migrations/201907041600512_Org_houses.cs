namespace UNSData.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Org_houses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Organization_House",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Source = c.String(),
                    Contacts = c.String(),
                    House_HOUSEID = c.Guid(),
                    Organization_Id = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("fias.House", t => t.House_HOUSEID)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.House_HOUSEID)
                .Index(t => t.Organization_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Organization_House", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Organization_House", "House_HOUSEID", "fias.House");
            DropIndex("dbo.Organization_House", new[] { "Organization_Id" });
            DropIndex("dbo.Organization_House", new[] { "House_HOUSEID" });
            DropTable("dbo.Organization_House");
        }
    }
}
