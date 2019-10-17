namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _683 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LightingEquipment",
                c => new
                    {
                        LightingEquipmentID = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LightingEquipmentID);
            
            CreateTable(
                "dbo.LightBoxElements",
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
                "dbo.DuLB_U",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .ForeignKey("dbo.LightBoxElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            AlterColumn("dbo.ConstractionElements", "Discriminator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DuLB_U", "AddressObject_ConstractionElementID", "dbo.LightBoxElements");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.LightBoxElements", "LightingEquipment_LightingEquipmentID", "dbo.LightingEquipment");
            DropForeignKey("dbo.LightBoxElements", "ConstractionElementID", "dbo.ConstractionElements");
            DropIndex("dbo.DuLB_U", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.LightBoxElements", new[] { "LightingEquipment_LightingEquipmentID" });
            DropIndex("dbo.LightBoxElements", new[] { "ConstractionElementID" });
            AlterColumn("dbo.ConstractionElements", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.DuLB_U");
            DropTable("dbo.LightBoxElements");
            DropTable("dbo.LightingEquipment");
        }
    }
}
