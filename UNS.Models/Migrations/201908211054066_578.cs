namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _578 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RawAddress", "DirtyAddress", c => c.String(maxLength: 4000));
        }

        public override void Down()
        {
            DropColumn("dbo.RawAddress", "DirtyAddress");
        }
    }
}
