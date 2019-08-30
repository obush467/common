namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _558 : DbMigration
    {
        public override void Up()
        {
            // DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            RenameColumn("dbo.PersonPositions", "Organization_Id", "Organization_Id1");
            CreateIndex("dbo.PersonPositions", "Organization_Id1");

            //AddForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id1", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            AlterColumn("dbo.PersonPositions", "Organization_Id1", c => c.Guid(nullable: false));
            RenameIndex(table: "dbo.Organizations_Phones", name: "IX_Organization_ID", newName: "IX_Organizations_ID");
            RenameIndex(table: "dbo.Organizations_Emails", name: "IX_Organization_ID", newName: "IX_Organizations_ID");
            RenameColumn(table: "dbo.Organizations_Phones", name: "Organization_ID", newName: "Organizations_ID");
            RenameColumn(table: "dbo.Organizations_Emails", name: "Organization_ID", newName: "Organizations_ID");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
