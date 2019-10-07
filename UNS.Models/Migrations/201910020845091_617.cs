namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _617 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.integraDU", "Refusal", c => c.String(maxLength: 255));
            DropColumn("dbo.integraDU", "ОТКАЗ");
        }

        public override void Down()
        {
            AddColumn("dbo.integraDU", "ОТКАЗ", c => c.DateTime());
            DropColumn("dbo.integraDU", "Refusal");
        }
    }
}
