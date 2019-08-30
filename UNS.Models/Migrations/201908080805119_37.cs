namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _37 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("address.AdmArea", "AreaType", c => c.String(nullable: true, maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("address.AdmArea", "AreaType", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
