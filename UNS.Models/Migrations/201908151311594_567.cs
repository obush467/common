namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _567 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropForeignKey("dbo.FaxItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropForeignKey("dbo.PersonPositions1", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions1", "Person_Id", "dbo.Persons");
            DropForeignKey("dbo.PhoneItems", "PersonPosition1_Id", "dbo.PersonPositions1");
            DropForeignKey("dbo.PersonPositions1", "PositionType_Id", "dbo.PersonPositionTypes");
            DropForeignKey("dbo.PersonPositions1", "Organization_Id1", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "Organization_Id3", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id3" });
            DropIndex("dbo.EmailItems", new[] { "PersonPosition1_Id" });
            DropIndex("dbo.FaxItems", new[] { "PersonPosition1_Id" });
            DropIndex("dbo.PhoneItems", new[] { "PersonPosition1_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "Organization_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "Person_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "PositionType_Id" });
            DropIndex("dbo.PersonPositions1", new[] { "Organization_Id1" });
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id3", newName: "Organization_Id");
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
            //DropColumn("dbo.PersonPositions", "Organization_Id");
            DropColumn("dbo.EmailItems", "PersonPosition1_Id");
            DropColumn("dbo.FaxItems", "PersonPosition1_Id");
            DropColumn("dbo.PhoneItems", "PersonPosition1_Id");
            DropTable("dbo.PersonPositions1");
        }

        public override void Down()
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
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.PhoneItems", "PersonPosition1_Id", c => c.Guid());
            AddColumn("dbo.FaxItems", "PersonPosition1_Id", c => c.Guid());
            AddColumn("dbo.EmailItems", "PersonPosition1_Id", c => c.Guid());
            AddColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.PersonPositions", "Organization_Id2", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id2" });
            AlterColumn("dbo.PersonPositions", "Organization_Id2", c => c.Guid());
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id2", newName: "Organization_Id3");
            CreateIndex("dbo.PersonPositions1", "Organization_Id1");
            CreateIndex("dbo.PersonPositions1", "PositionType_Id");
            CreateIndex("dbo.PersonPositions1", "Person_Id");
            CreateIndex("dbo.PersonPositions1", "Organization_Id");
            CreateIndex("dbo.PhoneItems", "PersonPosition1_Id");
            CreateIndex("dbo.FaxItems", "PersonPosition1_Id");
            CreateIndex("dbo.EmailItems", "PersonPosition1_Id");
            CreateIndex("dbo.PersonPositions", "Organization_Id3");
            AddForeignKey("dbo.PersonPositions", "Organization_Id3", "dbo.Organizations", "Id");
            AddForeignKey("dbo.PersonPositions1", "Organization_Id1", "dbo.Organizations", "Id");
            AddForeignKey("dbo.PersonPositions1", "PositionType_Id", "dbo.PersonPositionTypes", "Id");
            AddForeignKey("dbo.PhoneItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
            AddForeignKey("dbo.PersonPositions1", "Person_Id", "dbo.Persons", "Id");
            AddForeignKey("dbo.PersonPositions1", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FaxItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
            AddForeignKey("dbo.EmailItems", "PersonPosition1_Id", "dbo.PersonPositions1", "Id");
        }
    }
}
