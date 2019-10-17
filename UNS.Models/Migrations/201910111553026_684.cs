namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _684 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DuS", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuLB_U", "AddressObject_ConstractionElementID", "dbo.LightBoxElements");
            DropIndex("dbo.DuS", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuLB_U", new[] { "AddressObject_ConstractionElementID" });
            CreateTable(
                "dbo.LightBoxTwoFieldElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false),
                        LightingEquipment_LightingEquipmentID = c.Guid(),
                        MaxPower = c.Single(nullable: false),
                        MaxBrightness = c.Single(nullable: false),
                        MinPower = c.Single(nullable: false),
                        MinBrightness = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ConstractionElementID)
                .ForeignKey("dbo.ConstractionElements", t => t.ConstractionElementID)
                .ForeignKey("dbo.LightingEquipment", t => t.LightingEquipment_LightingEquipmentID)
                .Index(t => t.ConstractionElementID)
                .Index(t => t.LightingEquipment_LightingEquipmentID);
            
            CreateTable(
                "dbo.DuLB_S",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuS", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuUD", t => t.ID)
                .Index(t => t.ID);
            
            DropColumn("dbo.DuS", "AddressObject_ConstractionElementID");
            DropColumn("dbo.DuLB_U", "AddressObject_ConstractionElementID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DuLB_U", "AddressObject_ConstractionElementID", c => c.Guid());
            AddColumn("dbo.DuS", "AddressObject_ConstractionElementID", c => c.Guid());
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DuLB_S", "ID", "dbo.DuS");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "LightingEquipment_LightingEquipmentID", "dbo.LightingEquipment");
            DropForeignKey("dbo.LightBoxTwoFieldElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DuLB_S", new[] { "ID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "LightingEquipment_LightingEquipmentID" });
            DropIndex("dbo.LightBoxTwoFieldElements", new[] { "ConstractionElementID" });
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DuLB_S");
            DropTable("dbo.LightBoxTwoFieldElements");
            CreateIndex("dbo.DuLB_U", "AddressObject_ConstractionElementID");
            CreateIndex("dbo.DuS", "AddressObject_ConstractionElementID");
            AddForeignKey("dbo.DuLB_U", "AddressObject_ConstractionElementID", "dbo.LightBoxElements", "ConstractionElementID");
            AddForeignKey("dbo.DuS", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
        }
    }
}
