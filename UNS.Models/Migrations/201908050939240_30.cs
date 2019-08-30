namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _30 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PersonPositions", "Organization_Id2", "dbo.Organizations");
            //DropIndex("dbo.PersonPositions", new[] { "Organization_Id2" });
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id2", newName: "Organization_Id");
            //AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            //CreateIndex("dbo.PersonPositions", "Organization_Id");
            //AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid());
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id2");
            CreateIndex("dbo.PersonPositions", "Organization_Id2");
            AddForeignKey("dbo.PersonPositions", "Organization_Id2", "dbo.Organizations", "Id");
        }
    }
}
