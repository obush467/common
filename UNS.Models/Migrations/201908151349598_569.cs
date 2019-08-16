namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _569 : DbMigration
    {
        public override void Up()
        {
            /*DropForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            DropIndex("dbo.PersonPositions", new[] { "Organization_Id1" });
            DropColumn("dbo.PersonPositions", "Organization_Id");
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id1", newName: "Organization_Id");
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.PersonPositions", "Organization_Id");*/
        }
        
        public override void Down()
        {
            /*DropIndex("dbo.PersonPositions", new[] { "Organization_Id" });
            AlterColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.PersonPositions", name: "Organization_Id", newName: "Organization_Id1");
            AddColumn("dbo.PersonPositions", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.PersonPositions", "Organization_Id1");
            CreateIndex("dbo.PersonPositions", "Organization_Id");
            AddForeignKey("dbo.PersonPositions", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);*/
        }
    }
}
