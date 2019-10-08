namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _633 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AddressStatus", newName: "AddressStatuses");
            MoveTable(name: "dbo.AddressStatuses", newSchema: "fias");
            DropForeignKey("dbo.PassportContents", "ID", "dbo.integraDUStages");
            DropForeignKey("fias.AddressBases", "AddressStatus_ID", "dbo.AddressStatus");
            DropIndex("dbo.PassportContents", new[] { "ID" });
            //DropPrimaryKey("fias.AddressStatuses");
            CreateTable(
                "dbo.InstallationPlace",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        InstallationPlaceType = c.String(),
                        Location_LocationID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("address.Location", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "address.Location",
                c => new
                    {
                        LocationID = c.Guid(nullable: false, identity: true),
                        WGS84 = c.Geography(),
                        EGKO = c.Geometry(),
                        MGGT = c.Geometry(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.ConstractionElements",
                c => new
                    {
                        ConstractionElementID = c.Guid(nullable: false, identity: true),
                        ContentText = c.String(),
                        ContentImage = c.Binary(),
                        PermanentContent = c.Boolean(),
                        Height = c.Single(nullable: false),
                        Width = c.Single(nullable: false),
                        SurfaceArea = c.Single(nullable: false),
                        MaxPower = c.Single(),
                        MaxBrightness = c.Single(),
                        MinPower = c.Single(),
                        MinBrightness = c.Single(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ConstractionElementID);
            
            CreateTable(
                "fias.AddressRoom",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FLATNUMBER = c.String(nullable: false, maxLength: 50),
                        FLATTYPE = c.Int(nullable: false),
                        ROOMNUMBER = c.String(maxLength: 50),
                        ROOMTYPE = c.Int(),
                        ROOMCADNUM = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "fias.AddressStead",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NUMBER = c.String(maxLength: 120),
                        COUNTER = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DUTechnicalCertificates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UNIU = c.String(),
                        OutDate = c.DateTime(nullable: false),
                        DUType = c.String(),
                        Okrug = c.String(),
                        District = c.String(),
                        AddressObject = c.String(),
                        AddressHouse = c.String(),
                        DateManufacture = c.DateTime(nullable: false),
                        ContentObjectFullPath = c.String(),
                        ContentHouseFullPath = c.String(),
                        Number = c.String(),
                        Stage = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DuU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.InstallationPlace", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressObject_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressObject_ConstractionElementID);
            
            CreateTable(
                "dbo.DuLB_U",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        U_ContentText2 = c.String(),
                        U_ContentImage2 = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressHouse_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuU", t => t.ID)
                .ForeignKey("dbo.ConstractionElements", t => t.AddressHouse_ConstractionElementID)
                .Index(t => t.ID)
                .Index(t => t.AddressHouse_ConstractionElementID);
            
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuUD", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DU_K_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DuLB_UD", t => t.ID)
                .Index(t => t.ID);
            
            AlterColumn("fias.AddressBases", "Discriminator", c => c.String(maxLength: 128));
            AlterColumn("fias.AddressStatuses", "ID", c => c.Guid(nullable: false, identity: true));
            //AddPrimaryKey("fias.AddressStatuses", "ID");
            AddForeignKey("fias.AddressBases", "AddressStatus_ID", "fias.AddressStatuses", "ID");
            DropColumn("fias.AddressBases", "FLATNUMBER");
            DropColumn("fias.AddressBases", "FLATTYPE");
            DropColumn("fias.AddressBases", "ROOMNUMBER");
            DropColumn("fias.AddressBases", "ROOMTYPE");
            DropColumn("fias.AddressBases", "ROOMCADNUM");
            DropColumn("fias.AddressBases", "NUMBER");
            DropColumn("fias.AddressBases", "COUNTER");
            DropTable("dbo.PassportContents");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            AddColumn("fias.AddressBases", "COUNTER", c => c.Int());
            AddColumn("fias.AddressBases", "NUMBER", c => c.String(maxLength: 120));
            AddColumn("fias.AddressBases", "ROOMCADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressBases", "ROOMTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "ROOMNUMBER", c => c.String(maxLength: 50));
            AddColumn("fias.AddressBases", "FLATTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "FLATNUMBER", c => c.String(maxLength: 50));
            DropForeignKey("fias.AddressBases", "AddressStatus_ID", "fias.AddressStatuses");
            DropForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD");
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.DUTechnicalCertificates", "Id", "dbo.Documents");
            DropForeignKey("fias.AddressStead", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressRoom", "ID", "fias.AddressBases");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropIndex("dbo.DU_K_UD", new[] { "ID" });
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.DUTechnicalCertificates", new[] { "Id" });
            DropIndex("fias.AddressStead", new[] { "ID" });
            DropIndex("fias.AddressRoom", new[] { "ID" });
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationID" });
            DropPrimaryKey("fias.AddressStatuses");
            AlterColumn("fias.AddressStatuses", "ID", c => c.Guid(nullable: false));
            AlterColumn("fias.AddressBases", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.DU_K_UD");
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuS");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.DuU");
            DropTable("dbo.DUTechnicalCertificates");
            DropTable("fias.AddressStead");
            DropTable("fias.AddressRoom");
            DropTable("dbo.ConstractionElements");
            DropTable("address.Location");
            DropTable("dbo.InstallationPlace");
            AddPrimaryKey("fias.AddressStatuses", "ID");
            CreateIndex("dbo.PassportContents", "ID");
            AddForeignKey("fias.AddressBases", "AddressStatus_ID", "dbo.AddressStatus", "ID");
            AddForeignKey("dbo.PassportContents", "ID", "dbo.integraDUStages", "ID");
            MoveTable(name: "fias.AddressStatuses", newSchema: "dbo");
            RenameTable(name: "dbo.AddressStatuses", newName: "AddressStatus");
        }
    }
}
