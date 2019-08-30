namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _17 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Organizations_Faxeses", newName: "Organizations_Faxes");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.Organizations_Faxes", newName: "Organizations_Faxeses");
        }
    }
}
