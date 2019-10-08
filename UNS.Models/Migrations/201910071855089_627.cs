namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _627 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "fias.AddressBases", newSchema: "dbo");
            MoveTable(name: "fias.AddressCodes", newSchema: "dbo");
            DropForeignKey("fias.AddressCodes", "AddressCode_ID", "fias.AddressBases");
            DropForeignKey("fias.AddressPrevNext", "AddressBase_ID", "fias.AddressBases");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropForeignKey("fias.AddressObject1s", "ID", "fias.AddressBases");
            DropForeignKey("fias.Room1", "ID", "fias.AddressBases");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD");
            DropForeignKey("fias.Stead1", "ID", "fias.AddressBases");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "fias.AddressCodes");
            DropIndex("dbo.AddressCodes", new[] { "AddressCode_ID" });
            DropIndex("fias.AddressPrevNext", new[] { "AddressBase_ID" });
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationID" });
            DropIndex("fias.AddressObject1s", new[] { "ID" });
            DropIndex("fias.Room1", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DU_K_UD", new[] { "ID" });
            DropIndex("fias.Stead1", new[] { "ID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            //DropPrimaryKey("dbo.AddressCodes");
            AddColumn("dbo.AddressBases", "FLATNUMBER", c => c.String(maxLength: 50));
            AddColumn("dbo.AddressBases", "FLATTYPE", c => c.Int());
            AddColumn("dbo.AddressBases", "ROOMNUMBER", c => c.String(maxLength: 50));
            AddColumn("dbo.AddressBases", "ROOMTYPE", c => c.Int());
            AddColumn("dbo.AddressBases", "ROOMCADNUM", c => c.String(maxLength: 100));
            AddColumn("dbo.AddressBases", "FORMALNAME", c => c.String(maxLength: 120));
            AddColumn("dbo.AddressBases", "AUTOCODE", c => c.String(maxLength: 1));
            AddColumn("dbo.AddressBases", "AREACODE", c => c.String(maxLength: 3));
            AddColumn("dbo.AddressBases", "CITYCODE", c => c.String(maxLength: 3));
            AddColumn("dbo.AddressBases", "CTARCODE", c => c.String(maxLength: 3));
            AddColumn("dbo.AddressBases", "PLACECODE", c => c.String(maxLength: 3));
            AddColumn("dbo.AddressBases", "STREETCODE", c => c.String(maxLength: 4));
            AddColumn("dbo.AddressBases", "EXTRCODE", c => c.String(maxLength: 4));
            AddColumn("dbo.AddressBases", "SEXTCODE", c => c.String(maxLength: 3));
            AddColumn("dbo.AddressBases", "OFFNAME", c => c.String(maxLength: 120));
            AddColumn("dbo.AddressBases", "SHORTNAME", c => c.String(maxLength: 10));
            AddColumn("dbo.AddressBases", "AOLEVEL", c => c.Int());
            AddColumn("dbo.AddressBases", "CODE", c => c.String(maxLength: 17));
            AddColumn("dbo.AddressBases", "PLAINCODE", c => c.String(maxLength: 15));
            AddColumn("dbo.AddressBases", "ACTSTATUS", c => c.Int());
            AddColumn("dbo.AddressBases", "CENTSTATUS", c => c.Int());
            AddColumn("dbo.AddressBases", "CURRSTATUS", c => c.Int());
            AddColumn("dbo.AddressBases", "NUMBER", c => c.String(maxLength: 120));
            AddColumn("dbo.AddressBases", "COUNTER", c => c.Int());
            AddColumn("dbo.AddressBases", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AddressCodes", "AddressCode_ID", c => c.Guid(nullable: false));
            //AddPrimaryKey("dbo.AddressCodes", "AddressCode_ID");
            AddForeignKey("dbo.AddressBases", "AddressCode_AddressCode_ID", "dbo.AddressCodes", "AddressCode_ID");
            DropTable("fias.AddressPrevNext");
            DropTable("dbo.InstallationPlace");
            DropTable("address.Location");
            DropTable("dbo.ConstractionElements");
            DropTable("fias.AddressObject1s");
            DropTable("fias.Room1");
            DropTable("dbo.DuU");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DU_K_UD");
            DropTable("fias.Stead1");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.DuS");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DuS",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        U_ContentText2 = c.String(),
                        U_ContentImage2 = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_U",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.Stead1",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NUMBER = c.String(maxLength: 120),
                        COUNTER = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DU_K_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuLB_UD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuUD",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressHouse_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DuU",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AddressObject_ConstractionElementID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.Room1",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FLATNUMBER = c.String(nullable: false, maxLength: 50),
                        FLATTYPE = c.Int(nullable: false),
                        ROOMNUMBER = c.String(maxLength: 50),
                        ROOMTYPE = c.Int(),
                        ROOMCADNUM = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.AddressObject1s",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FORMALNAME = c.String(maxLength: 120),
                        AUTOCODE = c.String(maxLength: 1),
                        AREACODE = c.String(maxLength: 3),
                        CITYCODE = c.String(maxLength: 3),
                        CTARCODE = c.String(maxLength: 3),
                        PLACECODE = c.String(maxLength: 3),
                        STREETCODE = c.String(maxLength: 4),
                        EXTRCODE = c.String(maxLength: 4),
                        SEXTCODE = c.String(maxLength: 3),
                        OFFNAME = c.String(maxLength: 120),
                        SHORTNAME = c.String(maxLength: 10),
                        AOLEVEL = c.Int(nullable: false),
                        CODE = c.String(maxLength: 17),
                        PLAINCODE = c.String(maxLength: 15),
                        ACTSTATUS = c.Int(),
                        CENTSTATUS = c.Int(),
                        CURRSTATUS = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "dbo.InstallationPlace",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        RegistrationNumber = c.String(),
                        InstallationPlaceType = c.String(),
                        Location_LocationID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.AddressPrevNext",
                c => new
                    {
                        AddressBase_ID = c.Guid(nullable: false),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressBase_ID);
            
            DropForeignKey("dbo.AddressBases", "AddressCode_AddressCode_ID", "dbo.AddressCodes");
            DropPrimaryKey("dbo.AddressCodes");
            AlterColumn("dbo.AddressCodes", "AddressCode_ID", c => c.Guid(nullable: false, identity: true));
            DropColumn("dbo.AddressBases", "Discriminator");
            DropColumn("dbo.AddressBases", "COUNTER");
            DropColumn("dbo.AddressBases", "NUMBER");
            DropColumn("dbo.AddressBases", "CURRSTATUS");
            DropColumn("dbo.AddressBases", "CENTSTATUS");
            DropColumn("dbo.AddressBases", "ACTSTATUS");
            DropColumn("dbo.AddressBases", "PLAINCODE");
            DropColumn("dbo.AddressBases", "CODE");
            DropColumn("dbo.AddressBases", "AOLEVEL");
            DropColumn("dbo.AddressBases", "SHORTNAME");
            DropColumn("dbo.AddressBases", "OFFNAME");
            DropColumn("dbo.AddressBases", "SEXTCODE");
            DropColumn("dbo.AddressBases", "EXTRCODE");
            DropColumn("dbo.AddressBases", "STREETCODE");
            DropColumn("dbo.AddressBases", "PLACECODE");
            DropColumn("dbo.AddressBases", "CTARCODE");
            DropColumn("dbo.AddressBases", "CITYCODE");
            DropColumn("dbo.AddressBases", "AREACODE");
            DropColumn("dbo.AddressBases", "AUTOCODE");
            DropColumn("dbo.AddressBases", "FORMALNAME");
            DropColumn("dbo.AddressBases", "ROOMCADNUM");
            DropColumn("dbo.AddressBases", "ROOMTYPE");
            DropColumn("dbo.AddressBases", "ROOMNUMBER");
            DropColumn("dbo.AddressBases", "FLATTYPE");
            DropColumn("dbo.AddressBases", "FLATNUMBER");
            AddPrimaryKey("dbo.AddressCodes", "AddressCode_ID");
            CreateIndex("dbo.DuS", "ID");
            CreateIndex("dbo.DuLB_U", "ID");
            CreateIndex("fias.Stead1", "ID");
            CreateIndex("dbo.DU_K_UD", "ID");
            CreateIndex("dbo.DuLB_UD", "ID");
            CreateIndex("dbo.DuUD", "AddressHouse_ConstractionElementID");
            CreateIndex("dbo.DuUD", "ID");
            CreateIndex("dbo.DuU", "AddressObject_ConstractionElementID");
            CreateIndex("dbo.DuU", "ID");
            CreateIndex("fias.Room1", "ID");
            CreateIndex("fias.AddressObject1s", "ID");
            CreateIndex("dbo.InstallationPlace", "Location_LocationID");
            CreateIndex("fias.AddressPrevNext", "AddressBase_ID");
            CreateIndex("dbo.AddressCodes", "AddressCode_ID");
            AddForeignKey("fias.AddressBases", "AddressCode_AddressCode_ID", "fias.AddressCodes", "AddressCode_ID");
            AddForeignKey("dbo.DuS", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DuLB_U", "ID", "dbo.DuU", "ID");
            AddForeignKey("fias.Stead1", "ID", "fias.AddressBases", "ID");
            AddForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD", "ID");
            AddForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD", "ID");
            AddForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace", "ID");
            AddForeignKey("fias.Room1", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressObject1s", "ID", "fias.AddressBases", "ID");
            AddForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location", "LocationID");
            AddForeignKey("fias.AddressPrevNext", "AddressBase_ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressCodes", "AddressCode_ID", "fias.AddressBases", "ID");
            MoveTable(name: "dbo.AddressCodes", newSchema: "fias");
            MoveTable(name: "dbo.AddressBases", newSchema: "fias");
        }
    }
}
