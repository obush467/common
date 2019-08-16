namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.integraDU", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.integraDU", "Organization_Id");
            AddForeignKey("dbo.integraDU", "Organization_Id", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.integraDU", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.integraDU", new[] { "Organization_Id" });
            DropColumn("dbo.integraDU", "Organization_Id");
        }
    }
}
