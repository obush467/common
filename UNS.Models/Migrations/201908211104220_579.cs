namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _579 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerRawAddress", "TypeOwner1", c => c.String(maxLength: 50));
            Sql("UPDATE O SET TypeOwner1 = TypeOwner from[dbo].[OwnerRawAddress] O INNER JOIN RawAddress R ON R.ID = O.ID");
        }

        public override void Down()
        {
            DropColumn("dbo.OwnerRawAddress", "TypeOwner1");
        }
    }
}
