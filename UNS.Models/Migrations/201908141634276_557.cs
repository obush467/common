namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _557 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Organizations_Faxes", name: "Organizations_ID", newName: "Organization_ID");
            RenameIndex(table: "dbo.Organizations_Faxes", name: "IX_Organizations_ID", newName: "IX_Organization_ID");
        }

        public override void Down()
        {
            RenameIndex(table: "dbo.Organizations_Faxes", name: "IX_Organization_ID", newName: "IX_Organizations_ID");
            RenameColumn(table: "dbo.Organizations_Faxes", name: "Organization_ID", newName: "Organizations_ID");
        }
    }
}
