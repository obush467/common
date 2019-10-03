namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _616 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PassportContents",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ContentObjectFullPath = c.String(),
                        ContentHouseFullPath = c.String(),
                        DateManufacture = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.integraDUStages", t => t.ID)
                .Index(t => t.ID);
            
            //DropTable("dbo.IntegraDUExcelLayouts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IntegraDUExcelLayouts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Stage = c.String(),
                        Number = c.Int(),
                        UNIU = c.String(),
                        DUType = c.String(),
                        Okrug = c.String(),
                        District = c.String(),
                        AddressObject = c.String(),
                        AddressHouse = c.String(),
                        ContentObject = c.String(),
                        ContentHouse = c.String(),
                        ContentObjectFullPath = c.String(),
                        ContentHouseFullPath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.PassportContents", "ID", "dbo.integraDUStages");
            DropIndex("dbo.PassportContents", new[] { "ID" });
            DropTable("dbo.PassportContents");
        }
    }
}
