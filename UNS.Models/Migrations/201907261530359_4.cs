namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "OKOPF", c => c.String(maxLength: 5));
            AddColumn("dbo.Organizations", "UNK", c => c.String(maxLength: 6));
            AddColumn("dbo.Organizations", "OKVED", c => c.String(maxLength: 100));
            AddColumn("dbo.Organizations", "OGS", c => c.String(maxLength: 50));
            AddColumn("dbo.Organizations", "OKFS", c => c.String(maxLength: 3));
            AddColumn("dbo.Organizations", "OKTMO", c => c.String(maxLength: 11));
        }

        public override void Down()
        {
            DropColumn("dbo.Organizations", "OKTMO");
            DropColumn("dbo.Organizations", "OKFS");
            DropColumn("dbo.Organizations", "OGS");
            DropColumn("dbo.Organizations", "OKVED");
            DropColumn("dbo.Organizations", "UNK");
            DropColumn("dbo.Organizations", "OKOPF");
        }
    }
}
