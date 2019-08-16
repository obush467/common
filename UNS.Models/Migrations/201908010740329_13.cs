namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FaxItems", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.FaxItems", "Organization_Id");
            AddForeignKey("dbo.FaxItems", "Organization_Id", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.FaxItems", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.FaxItems", new[] { "Organization_Id" });
            DropColumn("dbo.FaxItems", "Organization_Id");
        }
    }
}
