namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _560 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            //DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            //RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            //AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            //CreateIndex("dbo.PersonPositions", "Organization_Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid());
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id1");
            CreateIndex("dbo.PersonPositions", "Organization_Id1");
            AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }
    }
}
