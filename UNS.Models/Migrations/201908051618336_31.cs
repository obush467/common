namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _31 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations");
            //DropIndex("dbo.DirectorPositions", new[] { "Organization_Id" });
            //DropColumn("dbo.DirectorPositions", "Organization_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DirectorPositions", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.DirectorPositions", "Organization_Id");
            AddForeignKey("dbo.DirectorPositions", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
