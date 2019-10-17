namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _646 : DbMigration
    {
        public override void Up()
        {
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
                        FLATNUMBER = c.String(maxLength: 50),
                        FLATTYPE = c.Int(),
                        ROOMNUMBER = c.String(maxLength: 50),
                        ROOMTYPE = c.Int(),
                        ROOMCADNUM = c.String(maxLength: 100),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        AddressCode_ID = c.Guid(),
                        AddressStatus_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressCodes", t => t.AddressCode_ID)
                .ForeignKey("fias.AddressStatuses", t => t.AddressStatus_ID)
                .Index(t => t.AddressCode_ID)
                .Index(t => t.AddressStatus_ID);
            
            CreateTable(
                "fias.AddressBase_PrevNext",
                c => new
                    {
                        NEXTID = c.Guid(nullable: false),
                        PREVID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.NEXTID, t.PREVID })
                .ForeignKey("fias.AddressBases", t => t.NEXTID)
                .ForeignKey("fias.AddressBases", t => t.PREVID)
                .Index(t => t.NEXTID)
                .Index(t => t.PREVID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressBase_PrevNext", "PREVID", "fias.AddressBases");
            DropForeignKey("fias.AddressBase_PrevNext", "NEXTID", "fias.AddressBases");
            DropForeignKey("fias.AddressBases", "AddressStatus_ID", "fias.AddressStatuses");
            DropForeignKey("fias.AddressBases", "AddressCode_ID", "fias.AddressCodes");
            DropIndex("fias.AddressBase_PrevNext", new[] { "PREVID" });
            DropIndex("fias.AddressBase_PrevNext", new[] { "NEXTID" });
            DropIndex("fias.AddressBases", new[] { "AddressStatus_ID" });
            DropIndex("fias.AddressBases", new[] { "AddressCode_ID" });
            DropTable("fias.AddressBase_PrevNext");
            DropTable("fias.AddressBases");
        }
    }
}
