namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _562 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            // DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id1");
            AlterColumn("dbo.PersonPositions", "Organization_Id1", c => c.Guid());
            CreateIndex("dbo.PersonPositions", "Organization_Id1");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            AlterColumn("dbo.PersonPositions", "Organization_Id1", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
