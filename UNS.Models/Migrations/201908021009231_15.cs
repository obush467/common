namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Phone = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Organizations_Phones",
                c => new
                {
                    Organizations_ID = c.Guid(nullable: false),
                    PhoneItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.Organizations_ID, t.PhoneItem_ID })
                .ForeignKey("dbo.Organizations", t => t.Organizations_ID, cascadeDelete: true)
                .ForeignKey("dbo.PhoneItems", t => t.PhoneItem_ID, cascadeDelete: true)
                .Index(t => t.Organizations_ID)
                .Index(t => t.PhoneItem_ID);


        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations");
            DropForeignKey("dbo.OwnerRawAddress", "ID", "dbo.RawAddress");
            DropForeignKey("dbo.Organizations_Phones", "PhoneItem_ID", "dbo.PhoneItems");
            DropForeignKey("dbo.Organizations_Phones", "Organizations_ID", "dbo.Organizations");
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_ID" });
            DropIndex("dbo.OwnerRawAddress", new[] { "ID" });
            DropIndex("dbo.Organizations_Phones", new[] { "PhoneItem_ID" });
            DropIndex("dbo.Organizations_Phones", new[] { "Organizations_ID" });
            DropTable("dbo.OwnerRawAddress");
            DropTable("dbo.Organizations_Phones");
            DropTable("dbo.RawAddress");
            DropTable("dbo.PhoneItems");
        }
    }
}
