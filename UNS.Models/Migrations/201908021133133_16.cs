namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _16 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.FaxItems", "Organization_Id", "dbo.Organizations");
            //DropIndex("dbo.FaxItems", new[] { "Organization_Id" });
            CreateTable(
                "dbo.EmailItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.FaxItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Fax = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Organizations_Emails",
                c => new
                {
                    Organizations_ID = c.Guid(nullable: false),
                    EmailItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.Organizations_ID, t.EmailItem_ID })
                .ForeignKey("dbo.Organizations", t => t.Organizations_ID, cascadeDelete: true)
                .ForeignKey("dbo.EmailItems", t => t.EmailItem_ID, cascadeDelete: true)
                .Index(t => t.Organizations_ID)
                .Index(t => t.EmailItem_ID);

            CreateTable(
                "dbo.Organizations_Faxeses",
                c => new
                {
                    Organizations_ID = c.Guid(nullable: false),
                    FaxItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.Organizations_ID, t.FaxItem_ID })
                .ForeignKey("dbo.Organizations", t => t.Organizations_ID, cascadeDelete: true)
                .ForeignKey("dbo.FaxItems", t => t.FaxItem_ID, cascadeDelete: true)
                .Index(t => t.Organizations_ID)
                .Index(t => t.FaxItem_ID);

            CreateTable(
                "dbo.PersonPositions_EmailItems",
                c => new
                {
                    PersonPosition_ID = c.Guid(nullable: false),
                    EmailItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.PersonPosition_ID, t.EmailItem_ID })
                .ForeignKey("dbo.PersonPositions", t => t.PersonPosition_ID, cascadeDelete: true)
                .ForeignKey("dbo.EmailItems", t => t.EmailItem_ID, cascadeDelete: true)
                .Index(t => t.PersonPosition_ID)
                .Index(t => t.EmailItem_ID);

            CreateTable(
                "dbo.PersonPositions_Faxes",
                c => new
                {
                    PersonPosition_ID = c.Guid(nullable: false),
                    FaxItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.PersonPosition_ID, t.FaxItem_ID })
                .ForeignKey("dbo.PersonPositions", t => t.PersonPosition_ID, cascadeDelete: true)
                .ForeignKey("dbo.FaxItems", t => t.FaxItem_ID, cascadeDelete: true)
                .Index(t => t.PersonPosition_ID)
                .Index(t => t.FaxItem_ID);

            CreateTable(
                "dbo.PersonPositions_Phones",
                c => new
                {
                    PersonPosition_ID = c.Guid(nullable: false),
                    PhoneItem_ID = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.PersonPosition_ID, t.PhoneItem_ID })
                .ForeignKey("dbo.PersonPositions", t => t.PersonPosition_ID, cascadeDelete: true)
                .ForeignKey("dbo.PhoneItems", t => t.PhoneItem_ID, cascadeDelete: true)
                .Index(t => t.PersonPosition_ID)
                .Index(t => t.PhoneItem_ID);

            //AddColumn("dbo.AccountantGeneralPositions", "Organization_Id", c => c.Guid());
            //CreateIndex("dbo.AccountantGeneralPositions", "Organization_Id");
            //AddForeignKey("dbo.AccountantGeneralPositions", "Organization_Id", "dbo.Organizations", "Id");
            //DropColumn("dbo.FaxItems", "Organization_Id");
        }

        public override void Down()
        {
            AddColumn("dbo.FaxItems", "Organization_Id", c => c.Guid());
            DropForeignKey("dbo.AccountantGeneralPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions_Phones", "PhoneItem_ID", "dbo.PhoneItems");
            DropForeignKey("dbo.PersonPositions_Phones", "PersonPosition_ID", "dbo.PersonPositions");
            DropForeignKey("dbo.PersonPositions_Faxes", "FaxItem_ID", "dbo.FaxItems");
            DropForeignKey("dbo.PersonPositions_Faxes", "PersonPosition_ID", "dbo.PersonPositions");
            DropForeignKey("dbo.PersonPositions_EmailItems", "EmailItem_ID", "dbo.EmailItems");
            DropForeignKey("dbo.PersonPositions_EmailItems", "PersonPosition_ID", "dbo.PersonPositions");
            DropForeignKey("dbo.Organizations_Faxeses", "FaxItem_ID", "dbo.FaxItems");
            DropForeignKey("dbo.Organizations_Faxeses", "Organizations_ID", "dbo.Organizations");
            DropForeignKey("dbo.Organizations_Emails", "EmailItem_ID", "dbo.EmailItems");
            DropForeignKey("dbo.Organizations_Emails", "Organizations_ID", "dbo.Organizations");
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Organization_Id" });
            DropIndex("dbo.PersonPositions_Phones", new[] { "PhoneItem_ID" });
            DropIndex("dbo.PersonPositions_Phones", new[] { "PersonPosition_ID" });
            DropIndex("dbo.PersonPositions_Faxes", new[] { "FaxItem_ID" });
            DropIndex("dbo.PersonPositions_Faxes", new[] { "PersonPosition_ID" });
            DropIndex("dbo.PersonPositions_EmailItems", new[] { "EmailItem_ID" });
            DropIndex("dbo.PersonPositions_EmailItems", new[] { "PersonPosition_ID" });
            DropIndex("dbo.Organizations_Faxeses", new[] { "FaxItem_ID" });
            DropIndex("dbo.Organizations_Faxeses", new[] { "Organizations_ID" });
            DropIndex("dbo.Organizations_Emails", new[] { "EmailItem_ID" });
            DropIndex("dbo.Organizations_Emails", new[] { "Organizations_ID" });
            DropColumn("dbo.AccountantGeneralPositions", "Organization_Id");
            DropTable("dbo.PersonPositions_Phones");
            DropTable("dbo.PersonPositions_Faxes");
            DropTable("dbo.PersonPositions_EmailItems");
            DropTable("dbo.Organizations_Faxeses");
            DropTable("dbo.Organizations_Emails");
            DropTable("dbo.EmailItems");
            CreateIndex("dbo.FaxItems", "Organization_Id");
            AddForeignKey("dbo.FaxItems", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
