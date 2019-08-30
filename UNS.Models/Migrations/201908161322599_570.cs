namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _570 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons");
            DropIndex("dbo.PersonPositions", new[] { "Human_Id" });
            //DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            RenameColumn(table: "dbo.PersonPositions", name: "Human_Id", newName: "Person_Id");
            AlterColumn("dbo.PersonPositions", "Person_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.PersonPositions", "Person_Id");
            //CreateIndex("dbo.PersonPositions", "Organization_Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonPositions", "Person_Id", "dbo.Persons", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Person_Id", "dbo.Persons");
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Person_Id" });
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid());
            AlterColumn("dbo.PersonPositions", "Person_Id", c => c.Guid());
            RenameColumn(table: "dbo.PersonPositions", name: "Person_Id", newName: "Human_Id");
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            CreateIndex("dbo.PersonPositions", "Human_Id");
            AddForeignKey("dbo.PersonPositions", "Human_Id", "dbo.Persons", "Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
