namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _565 : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id2", newName: "Organization_Id3");
            //RenameColumn(table: "dbo.DirectorPositions", name: "Organization_Id2", newName: "Organization_Id");
            //RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id2", newName: "IX_Organization_Id3");
            //CreateIndex("dbo.DirectorPositions", "Organization_Id");
        }

        public override void Down()
        {
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id3", newName: "IX_Organization_Id2");
            RenameColumn(table: "dbo.DirectorPositions", name: "Organization_Id", newName: "Organization_Id2");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id3", newName: "Organization_Id2");
        }
    }
}
