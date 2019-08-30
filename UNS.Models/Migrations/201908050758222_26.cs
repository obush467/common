namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _26 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DirectorPositions11", newName: "DirectorPositions");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.DirectorPositions", newName: "DirectorPositions11");
        }
    }
}
