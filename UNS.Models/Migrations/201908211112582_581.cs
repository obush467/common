namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _581 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerRawAddress", "Contacts1", c => c.String());
            Sql("UPDATE O SET Contacts1 = Contacts from[dbo].[OwnerRawAddress] O INNER JOIN RawAddress R ON R.ID = O.ID");
        }

        public override void Down()
        {
            DropColumn("dbo.OwnerRawAddress", "Contacts1");
        }
    }
}
