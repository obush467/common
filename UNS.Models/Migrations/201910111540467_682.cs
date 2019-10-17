namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _682 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DuS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            AddColumn("dbo.ConstractionElements", "ContentText2", c => c.String());
            AddColumn("dbo.ConstractionElements", "ContentImage2", c => c.Binary());
            AddColumn("dbo.ConstractionElements", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuS", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropIndex("dbo.DuS", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            DropColumn("dbo.ConstractionElements", "Discriminator");
            DropColumn("dbo.ConstractionElements", "ContentImage2");
            DropColumn("dbo.ConstractionElements", "ContentText2");
            DropTable("dbo.DuS");
        }
    }
}
