namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _618 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SimplifiedLetter_IntegraDUStages",
                c => new
                    {
                        SimplifiedLetter_ID = c.Guid(nullable: false),
                        IntegraDUStages_ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.SimplifiedLetter_ID, t.IntegraDUStages_ID })
                .ForeignKey("dbo.SimplifiedLetter", t => t.SimplifiedLetter_ID, cascadeDelete: true)
                .ForeignKey("dbo.integraDUStages", t => t.IntegraDUStages_ID, cascadeDelete: true)
                .Index(t => t.SimplifiedLetter_ID)
                .Index(t => t.IntegraDUStages_ID);
            
            CreateTable(
                "dbo.SimplifiedLetter",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sender = c.String(),
                        Recipient = c.String(),
                        RecipientDirectorPosition = c.String(),
                        RecipientDirectorName = c.String(),
                        IncomingNumber = c.String(),
                        OutgoingNumber = c.String(),
                        IncomingDate = c.DateTime(),
                        OutgoingDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SimplifiedLetter", "Id", "dbo.Documents");
            DropForeignKey("dbo.SimplifiedLetter_IntegraDUStages", "IntegraDUStages_ID", "dbo.integraDUStages");
            DropForeignKey("dbo.SimplifiedLetter_IntegraDUStages", "SimplifiedLetter_ID", "dbo.SimplifiedLetter");
            DropIndex("dbo.SimplifiedLetter", new[] { "Id" });
            DropIndex("dbo.SimplifiedLetter_IntegraDUStages", new[] { "IntegraDUStages_ID" });
            DropIndex("dbo.SimplifiedLetter_IntegraDUStages", new[] { "SimplifiedLetter_ID" });
            DropTable("dbo.SimplifiedLetter");
            DropTable("dbo.SimplifiedLetter_IntegraDUStages");
        }
    }
}
