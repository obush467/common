namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _607 : DbMigration
    {
        public override void Up()
        {
           // DropForeignKey("dbo.integraDU", "IntegraDUStages_ID", "dbo.IntegraDUStages");
            //DropIndex("dbo.integraDU", new[] { "IntegraDUStages_ID" });
           // DropColumn("dbo.integraDU", "IntegraDUStages_ID");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.integraDU", "IntegraDUStages_ID", c => c.Guid(nullable: false));
           // CreateIndex("dbo.integraDU", "IntegraDUStages_ID");
           // AddForeignKey("dbo.integraDU", "IntegraDUStages_ID", "dbo.IntegraDUStages", "ID");
        }
    }
}
