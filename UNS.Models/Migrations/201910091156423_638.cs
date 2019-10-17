namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _638 : DbMigration
    {
        public override void Up()
        {
           /* RenameTable(name: "fias.AddressAOs", newName: "AddressBases");
            DropForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location");
            DropForeignKey("fias.AddressAOs", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressHouse", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressRoom", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressStead", "ID", "fias.AddressBases");
            DropForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace");
            DropForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuUD", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements");
            DropForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD");
            DropForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD");
            DropForeignKey("dbo.DuLB_U", "ID", "dbo.DuU");
            DropForeignKey("dbo.DuS", "ID", "dbo.DuU");
            DropIndex("dbo.InstallationPlace", new[] { "Location_LocationID" });
            DropIndex("fias.AddressBases", new[] { "ID" });
            DropIndex("fias.AddressHouse", new[] { "ID" });
            DropIndex("fias.AddressRoom", new[] { "ID" });
            DropIndex("fias.AddressStead", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "ID" });
            DropIndex("dbo.DuU", new[] { "AddressObject_ConstractionElementID" });
            DropIndex("dbo.DuUD", new[] { "ID" });
            DropIndex("dbo.DuUD", new[] { "AddressHouse_ConstractionElementID" });
            DropIndex("dbo.DuLB_UD", new[] { "ID" });
            DropIndex("dbo.DU_K_UD", new[] { "ID" });
            DropIndex("dbo.DuLB_U", new[] { "ID" });
            DropIndex("dbo.DuS", new[] { "ID" });
            AddColumn("fias.AddressBases", "GUID", c => c.Guid(nullable: false));
            AddColumn("fias.AddressBases", "PARENTGUID", c => c.Guid());
            AddColumn("fias.AddressBases", "NORMDOC", c => c.Guid());
            AddColumn("fias.AddressBases", "UPDATEDATE", c => c.DateTime());
            AddColumn("fias.AddressBases", "STARTDATE", c => c.DateTime());
            AddColumn("fias.AddressBases", "ENDDATE", c => c.DateTime());
            AddColumn("fias.AddressBases", "POSTALCODE", c => c.String(maxLength: 6));
            AddColumn("fias.AddressBases", "CADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressBases", "FLATNUMBER", c => c.String(maxLength: 50));
            AddColumn("fias.AddressBases", "FLATTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "ROOMNUMBER", c => c.String(maxLength: 50));
            AddColumn("fias.AddressBases", "ROOMTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "ROOMCADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressBases", "NUMBER", c => c.String(maxLength: 120));
            AddColumn("fias.AddressBases", "COUNTER", c => c.Int());
            AddColumn("fias.AddressBases", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("fias.AddressBases", "AddressCode_ID", c => c.Guid());
            AddColumn("fias.AddressBases", "AddressStatus_ID", c => c.Guid());
            AlterColumn("fias.AddressBases", "AOLEVEL", c => c.Int());
            DropTable("fias.AddressBases");
            DropTable("address.AddressCached");
            DropTable("dbo.InstallationPlace");
            DropTable("dbo.ConstractionElements");
            DropTable("address.Location");
            DropTable("fias.AddressHouse");
            DropTable("fias.AddressRoom");
            DropTable("fias.AddressStead");
            DropTable("dbo.DuU");
            DropTable("dbo.DuUD");
            DropTable("dbo.DuLB_UD");
            DropTable("dbo.DU_K_UD");
            DropTable("dbo.DuLB_U");
            DropTable("dbo.DuS");*/
        }
        
        public override void Down()
        {
            /*CreateTable(
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
                "fias.AddressStead",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NUMBER = c.String(maxLength: 120),
                        COUNTER = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.AddressHouse",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                "address.AddressCached",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        AddressGUID = c.Guid(nullable: false),
                        AddressPARENTGUID = c.Guid(nullable: false),
                        ItemAddress = c.String(nullable: false),
                        FullAddress = c.String(nullable: false),
                        ItemCategory = c.String(nullable: false),
                        ItemType = c.String(nullable: false),
                        STARTDATE = c.DateTime(nullable: false),
                        ENDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "fias.AddressBases",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        GUID = c.Guid(nullable: false),
                        PARENTGUID = c.Guid(),
                        NORMDOC = c.Guid(),
                        UPDATEDATE = c.DateTime(),
                        STARTDATE = c.DateTime(),
                        ENDDATE = c.DateTime(),
                        POSTALCODE = c.String(maxLength: 6),
                        CADNUM = c.String(maxLength: 100),
                        AddressCode_ID = c.Guid(),
                        AddressStatus_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("fias.AddressBases", "AOLEVEL", c => c.Int(nullable: false));
            DropColumn("fias.AddressBases", "AddressStatus_ID");
            DropColumn("fias.AddressBases", "AddressCode_ID");
            DropColumn("fias.AddressBases", "Discriminator");
            DropColumn("fias.AddressBases", "COUNTER");
            DropColumn("fias.AddressBases", "NUMBER");
            DropColumn("fias.AddressBases", "ROOMCADNUM");
            DropColumn("fias.AddressBases", "ROOMTYPE");
            DropColumn("fias.AddressBases", "ROOMNUMBER");
            DropColumn("fias.AddressBases", "FLATTYPE");
            DropColumn("fias.AddressBases", "FLATNUMBER");
            DropColumn("fias.AddressBases", "CADNUM");
            DropColumn("fias.AddressBases", "POSTALCODE");
            DropColumn("fias.AddressBases", "ENDDATE");
            DropColumn("fias.AddressBases", "STARTDATE");
            DropColumn("fias.AddressBases", "UPDATEDATE");
            DropColumn("fias.AddressBases", "NORMDOC");
            DropColumn("fias.AddressBases", "PARENTGUID");
            DropColumn("fias.AddressBases", "GUID");
            CreateIndex("dbo.DuS", "ID");
            CreateIndex("dbo.DuLB_U", "ID");
            CreateIndex("dbo.DU_K_UD", "ID");
            CreateIndex("dbo.DuLB_UD", "ID");
            CreateIndex("dbo.DuUD", "AddressHouse_ConstractionElementID");
            CreateIndex("dbo.DuUD", "ID");
            CreateIndex("dbo.DuU", "AddressObject_ConstractionElementID");
            CreateIndex("dbo.DuU", "ID");
            CreateIndex("fias.AddressStead", "ID");
            CreateIndex("fias.AddressRoom", "ID");
            CreateIndex("fias.AddressHouse", "ID");
            CreateIndex("fias.AddressBases", "ID");
            CreateIndex("dbo.InstallationPlace", "Location_LocationID");
            AddForeignKey("dbo.DuS", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DuLB_U", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DU_K_UD", "ID", "dbo.DuLB_UD", "ID");
            AddForeignKey("dbo.DuLB_UD", "ID", "dbo.DuUD", "ID");
            AddForeignKey("dbo.DuUD", "AddressHouse_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuUD", "ID", "dbo.DuU", "ID");
            AddForeignKey("dbo.DuU", "AddressObject_ConstractionElementID", "dbo.ConstractionElements", "ConstractionElementID");
            AddForeignKey("dbo.DuU", "ID", "dbo.InstallationPlace", "ID");
            AddForeignKey("fias.AddressStead", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressRoom", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressHouse", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressAOs", "ID", "fias.AddressBases", "ID");
            AddForeignKey("dbo.InstallationPlace", "Location_LocationID", "address.Location", "LocationID");
            RenameTable(name: "fias.AddressBases", newName: "AddressAOs");*/
        }
    }
}
