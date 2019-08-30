namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _580 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OwnerRawAddress", "TypeOwner", c => c.String(maxLength: 50));
            DropColumn("dbo.OwnerRawAddress", "TypeOwner1");
            DropColumn("dbo.RawAddress", "TypeOwner");
        }

        public override void Down()
        {
            AddColumn("dbo.RawAddress", "TypeOwner", c => c.String(maxLength: 50));
            AddColumn("dbo.OwnerRawAddress", "TypeOwner1", c => c.String(maxLength: 50));
            DropColumn("dbo.OwnerRawAddress", "TypeOwner");
        }
    }
}
