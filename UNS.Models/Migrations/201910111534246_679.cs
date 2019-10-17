namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _679 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropColumn("dbo.ConstractionElements", "ContentText2");
            DropColumn("dbo.ConstractionElements", "ContentImage2");
            DropColumn("dbo.ConstractionElements", "Discriminator");
            //DropTable("dbo.LightBoxElements");
            //DropTable("dbo.LightBoxTwoFieldElements");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LightBoxTwoFieldElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        MaxPower = c.Single(nullable: false),
                        MaxBrightness = c.Single(nullable: false),
                        MinPower = c.Single(nullable: false),
                        MinBrightness = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ConstractionElementID);
            
            CreateTable(
                "dbo.LightBoxElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        MaxPower = c.Single(nullable: false),
                        MaxBrightness = c.Single(nullable: false),
                        MinPower = c.Single(nullable: false),
                        MinBrightness = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ConstractionElementID);
            
            AddColumn("dbo.ConstractionElements", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("dbo.ConstractionElements", "ContentImage2", c => c.Binary());
            AddColumn("dbo.ConstractionElements", "ContentText2", c => c.String());
            CreateIndex("dbo.LightBoxTwoFieldElements", "ConstractionElementID");
            CreateIndex("dbo.LightBoxElements", "ConstractionElementID");
            AddForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
        }
    }
}
