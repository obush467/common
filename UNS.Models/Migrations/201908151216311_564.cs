namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _564 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id1", newName: "IX_Organization_Id2");
            //AddColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonPositions", "Organization_Id");
            RenameIndex(table: "dbo.PersonPositions", name: "IX_Organization_Id2", newName: "IX_Organization_Id1");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id2", newName: "Organization_Id1");
        }
    }
}
