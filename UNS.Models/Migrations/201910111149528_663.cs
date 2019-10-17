namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _663 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechProjects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Documents", "TechProject_Id", c => c.Guid());
            AddColumn("dbo.InstallationPlace", "TechProject_Id", c => c.Guid());
            CreateIndex("dbo.Documents", "TechProject_Id");
            CreateIndex("dbo.InstallationPlace", "TechProject_Id");
            AddForeignKey("dbo.Documents", "TechProject_Id", "dbo.TechProjects", "Id");
            AddForeignKey("dbo.InstallationPlace", "TechProject_Id", "dbo.TechProjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechProjects", "Id", "dbo.Documents");
            DropForeignKey("dbo.InstallationPlace", "TechProject_Id", "dbo.TechProjects");
            DropForeignKey("dbo.Documents", "TechProject_Id", "dbo.TechProjects");
            DropIndex("dbo.TechProjects", new[] { "Id" });
            DropIndex("dbo.InstallationPlace", new[] { "TechProject_Id" });
            DropIndex("dbo.Documents", new[] { "TechProject_Id" });
            DropColumn("dbo.InstallationPlace", "TechProject_Id");
            DropColumn("dbo.Documents", "TechProject_Id");
            DropTable("dbo.TechProjects");
        }
    }
}
