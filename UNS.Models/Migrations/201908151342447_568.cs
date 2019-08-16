namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _568 : DbMigration
    {
        public override void Up()
        {
            /*DropForeignKey("dbo.AccountantGeneralPositions", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.AccountantGeneralPositions", new[] { "Organization_Id" });
            DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id2", newName: "Organization_Id");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id3", newName: "Organization_Id1");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id2", newName: "IX_Organization_Id");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id3", newName: "IX_Organization_Id1");
            DropColumn("dbo.AccountantGeneralPositions", "Organization_Id");
            DropColumn("dbo.DirectorPositions", "Organization_Id");*/
        }
        
        public override void Down()
        {
            /*AddColumn("dbo.DirectorPositions", "Organization_Id", c => c.Guid());
            AddColumn("dbo.AccountantGeneralPositions", "Organization_Id", c => c.Guid());
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id1", newName: "IX_Organization_Id3");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id", newName: "IX_Organization_Id2");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id3");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id2");
            CreateIndex("dbo.DirectorPositions", "Organization_Id");
            CreateIndex("dbo.AccountantGeneralPositions", "Organization_Id");
            AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
            AddForeignKey("dbo.AccountantGeneralPositions", "Organization_Id", "dbo.Organizations", "Id");*/
        }
    }
}
