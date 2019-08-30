namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _566 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonPositions1",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    BeginDate = c.DateTime(),
                    EndDate = c.DateTime(),
                    Organization_Id = c.Guid(nullable: false),
                    Person_Id = c.Guid(),
                    PositionType_Id = c.Guid(),
                    Organization_Id1 = c.Guid(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.Persons", t => t.Person_Id)
                .ForeignKey("dbo.PersonPositionTypes", t => t.PositionType_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id1)
                .Index(t => t.Organization_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.PositionType_Id)
                .Index(t => t.Organization_Id1);

            AddColumn("dbo.EmailItems", "PersonPosition1_Id", c => c.Guid());
            AddColumn("dbo.FaxItems", "PersonPosition1_Id", c => c.Guid());
            AddColumn("dbo.PhoneItems", "PersonPosition1_Id", c => c.Guid());
            CreateIndex("dbo.EmailItems", "PersonPosition1_Id");
            CreateIndex("dbo.FaxItems", "PersonPosition1_Id");
            CreateIndex("dbo.PhoneItems", "PersonPosition1_Id");
            AddForeignKey("dbo.EmailItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
            AddForeignKey("dbo.FaxItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
            AddForeignKey("dbo.PhoneItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions1", "Organization_Id1", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions1", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.PhoneItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropForeignKey("dbo.PersonPositions1", "Person_Id", "dbo.Persons");
            DropForeignKey("dbo.PersonPositions1", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.FaxItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropForeignKey("dbo.EmailItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropIndex("dbo.PersonPositions1", new[] { "Organization_Id1" });
            DropIndex("dbo.PersonPositions1", new[] { "PositionType_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "Person_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "Organization_Id" });
            DropIndex("dbo.PhoneItems", new[] { "PersonPosition1_Id" });
            DropIndex("dbo.FaxItems", new[] { "PersonPosition1_Id" });
            DropIndex("dbo.EmailItems", new[] { "PersonPosition1_Id" });
            DropColumn("dbo.PhoneItems", "PersonPosition1_Id");
            DropColumn("dbo.FaxItems", "PersonPosition1_Id");
            DropColumn("dbo.EmailItems", "PersonPosition1_Id");
            DropTable("dbo.PersonPositions1");
        }
    }
}
