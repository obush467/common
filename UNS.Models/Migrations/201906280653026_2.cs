namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                 "dbo.IntegraDUExcelLayouts",
                 c => new
                     {
                         ID = c.Guid(nullable: false),
                         Stage = c.String(),
                         Number = c.Int(),
                         UNIU = c.String(),
                         DUType = c.String(),
                         Okrug = c.String(),
                         District = c.String(),
                         AddressObject = c.String(),
                         AddressHouse = c.String(),
                         ContentObject = c.String(),
                         ContentHouse = c.String(),
                         ContentObjectFullPath = c.String(),
                         ContentHouseFullPath = c.String(),
                     })
                 .PrimaryKey(t => t.ID);*/

        }

        public override void Down()
        {
            //DropTable("dbo.IntegraDUExcelLayouts");
        }
    }
}
