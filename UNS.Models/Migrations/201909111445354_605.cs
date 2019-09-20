namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _605 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.integraDU_works",
                c => new
                    {
                        integraDU_workID = c.Guid(nullable: false, identity: true),
                        IntegraDU_ID = c.Guid(nullable: false),
                        DateIssue = c.DateTime(),
                        DateСompletion = c.DateTime(),
                        DateReceiptFoto = c.DateTime(),
                        DatVerificationFoto = c.DateTime(),
                        Rollback = c.String(maxLength: 100),
                        Checker_Id = c.Guid(),
                        Worker_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.integraDU_workID)
                .ForeignKey("dbo.Persons", t => t.Checker_Id)
                .ForeignKey("dbo.integraDU", t => t.IntegraDU_ID)
                .ForeignKey("dbo.Persons", t => t.Worker_Id)
                .Index(t => t.IntegraDU_ID)
                .Index(t => t.Checker_Id)
                .Index(t => t.Worker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.integraDU_works", "Worker_Id", "dbo.Persons");
            DropForeignKey("dbo.integraDU_works", "IntegraDU_ID", "dbo.integraDU");
            DropForeignKey("dbo.integraDU_works", "Checker_Id", "dbo.Persons");
            DropIndex("dbo.integraDU_works", new[] { "Worker_Id" });
            DropIndex("dbo.integraDU_works", new[] { "Checker_Id" });
            DropIndex("dbo.integraDU_works", new[] { "IntegraDU_ID" });
            DropTable("dbo.integraDU_works");
        }
    }
}
