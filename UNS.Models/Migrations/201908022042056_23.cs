namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OwnerRawAddress55",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Organization_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RawAddress", t => t.ID)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.ID)
                .Index(t => t.Organization_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress55", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.OwnerRawAddress55", "ID", "dbo.RawAddress");
            DropIndex("dbo.OwnerRawAddress55", new[] { "Organization_Id" });
            DropIndex("dbo.OwnerRawAddress55", new[] { "ID" });
            DropTable("dbo.OwnerRawAddress55");
        }
    }
}
