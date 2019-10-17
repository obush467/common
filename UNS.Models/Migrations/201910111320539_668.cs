namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _668 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstallationPlaceDU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstallationPlaceDU", "ID", "dbo.InstallationPlace");
            DropIndex("dbo.InstallationPlaceDU", new[] { "ID" });
            DropTable("dbo.InstallationPlaceDU");
        }
    }
}
