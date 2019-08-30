namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _582 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.OwnerRawAddress", "Contacts1", "Contacts");
            DropColumn("dbo.RawAddress", "Contacts");
        }

        public override void Down()
        {

        }
    }
}
