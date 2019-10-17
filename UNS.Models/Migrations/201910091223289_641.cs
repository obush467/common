namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _641 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes");
            DropForeignKey("fias.AddressBases", "AddressStatus_ID", "fias.AddressStatuses");
            DropForeignKey("fias.AddressAOs", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressRoom", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressStead", "ID", "fias.AddressBases");
            DropIndex("fias.AddressBases", new[] { "AddressCode_ID" });
            DropIndex("fias.AddressBases", new[] { "AddressStatus_ID" });
            DropIndex("fias.AddressBase_PrevNext", new[] { "NEXTID" });
            DropIndex("fias.AddressBase_PrevNext", new[] { "PREVID" });
            DropIndex("fias.AddressAOs", new[] { "ID" });
            DropIndex("fias.AddressRoom", new[] { "ID" });
            DropIndex("fias.AddressStead", new[] { "ID" });
            //DropTable("fias.AddressAOs");
            DropTable("fias.AddressRoom");
            DropTable("fias.AddressStead");
            DropTable("fias.AddressBase_PrevNext");
            
            DropTable("fias.AddressCodes");
            DropTable("fias.AddressStatuses");
            //DropTable("fias.AddressBases");
            

        }
        
        public override void Down()
        {
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
                "fias.AddressAOs",
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
                "fias.AddressBase_PrevNext",
                c => new
                    {
                        NEXTID = c.Guid(nullable: false),
                        PREVID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.NEXTID, t.PREVID });
            
            CreateTable(
                "fias.AddressStatuses",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "fias.AddressCodes",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11),
                        OKTMO = c.String(maxLength: 11),
                        DIVTYPE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                        Discriminator = c.String(maxLength: 128),
                        AddressCode_ID = c.Guid(),
                        AddressStatus_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("fias.AddressStead", "ID");
            CreateIndex("fias.AddressRoom", "ID");
            CreateIndex("fias.AddressAOs", "ID");
            CreateIndex("fias.AddressBase_PrevNext", "PREVID");
            CreateIndex("fias.AddressBase_PrevNext", "NEXTID");
            CreateIndex("fias.AddressBases", "AddressStatus_ID");
            CreateIndex("fias.AddressBases", "AddressCode_ID");
            AddForeignKey("fias.AddressStead", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressRoom", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressAOs", "ID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressBase_PrevNext", "PREVID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressBase_PrevNext", "NEXTID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressBases", "AddressStatus_ID", "fias.AddressStatuses", "ID");
            AddForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes", "ID");
        }
    }
}
