namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _44 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("address.HouseFullBTI", "TotalArea", c => c.Double());
        }

        public override void Down()
        {
            AlterColumn("address.HouseFullBTI", "TotalArea", c => c.Single());
        }
    }
}
