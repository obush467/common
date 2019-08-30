namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _41 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("address.HouseFullBTI");
            AlterColumn("address.HouseFullBTI", "HouseFullBTI_ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("address.HouseFullBTI", "HouseFullBTI_ID");
        }

        public override void Down()
        {
            DropPrimaryKey("address.HouseFullBTI");
            AlterColumn("address.HouseFullBTI", "HouseFullBTI_ID", c => c.Guid(nullable: false));
            AddPrimaryKey("address.HouseFullBTI", "HouseFullBTI_ID");
        }
    }
}
