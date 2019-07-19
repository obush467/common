namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Org_houses1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Organization_House", "House_HOUSEID", "fias.House");
            DropIndex("dbo.Organization_House", new[] { "House_HOUSEID" });
            AddColumn("dbo.Organization_House", "HouseGUID", c => c.Guid(nullable: false));
            DropColumn("dbo.Organization_House", "House_HOUSEID");
        }

        public override void Down()
        {
            AddColumn("dbo.Organization_House", "House_HOUSEID", c => c.Guid());
            DropColumn("dbo.Organization_House", "HouseGUID");
            CreateIndex("dbo.Organization_House", "House_HOUSEID");
            AddForeignKey("dbo.Organization_House", "House_HOUSEID", "fias.House", "HOUSEID");
        }
    }
}
