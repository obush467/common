namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _585 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OwnerRawAddress", "ID", "dbo.RawAddress");
            //DropPrimaryKey("dbo.RawAddress");
            AlterColumn("dbo.RawAddress", "ID", c => c.Guid(nullable: false, identity: true));
            //AddPrimaryKey("dbo.RawAddress", "ID");
            AddForeignKey("dbo.OwnerRawAddress", "ID", "dbo.RawAddress", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress", "ID", "dbo.RawAddress");
            DropPrimaryKey("dbo.RawAddress");
            AlterColumn("dbo.RawAddress", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.RawAddress", "ID");
            AddForeignKey("dbo.OwnerRawAddress", "ID", "dbo.RawAddress", "ID");
        }
    }
}
