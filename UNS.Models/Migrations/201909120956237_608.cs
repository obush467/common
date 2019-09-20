namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _608 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.integraDU", "ID", "dbo.IntegraDUStages");
            //DropPrimaryKey("dbo.integraDUStages");
            //AlterColumn("dbo.integraDUStages", "ID", c => c.Guid(nullable: false, identity: true));
            //AddPrimaryKey("dbo.integraDUStages", "ID");
            //AddForeignKey("dbo.integraDU", "ID", "dbo.integraDUStages", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.integraDU", "ID", "dbo.integraDUStages");
            DropPrimaryKey("dbo.integraDUStages");
            AlterColumn("dbo.integraDUStages", "ID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.integraDUStages", "ID");
            AddForeignKey("dbo.integraDU", "ID", "dbo.IntegraDUStages", "ID");
        }
    }
}
