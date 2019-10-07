namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _600 : DbMigration
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
                    PrevNext_AddressBase_ID = c.Guid(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressPrevNext", t => t.PrevNext_AddressBase_ID)
                .Index(t => t.PrevNext_AddressBase_ID);

            CreateTable(
                "fias.AddressPrevNext",
                c => new
                {
                    AddressBase_ID = c.Guid(nullable: false),
                    PREVID = c.Guid(),
                    NEXTID = c.Guid(),
                    OPERSTATUS = c.Int(),
                    REGIONCODE = c.String(maxLength: 2),
                    LIVESTATUS = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.AddressBase_ID)
                .ForeignKey("fias.AddressBases", t => t.AddressBase_ID)
                .ForeignKey("fias.AddressBases", t => t.NEXTID)
                .ForeignKey("fias.AddressBases", t => t.PREVID)
                .Index(t => t.AddressBase_ID)
                .Index(t => t.PREVID)
                .Index(t => t.NEXTID);

        }

        public override void Down()
        {
            DropForeignKey("fias.AddressBases", "PrevNext_AddressBase_ID", "fias.AddressPrevNext");
            DropForeignKey("fias.AddressPrevNext", "PREVID", "fias.AddressBases");
            DropForeignKey("fias.AddressPrevNext", "NEXTID", "fias.AddressBases");
            DropForeignKey("fias.AddressPrevNext", "AddressBase_ID", "fias.AddressBases");
            DropIndex("fias.AddressPrevNext", new[] { "NEXTID" });
            DropIndex("fias.AddressPrevNext", new[] { "PREVID" });
            DropIndex("fias.AddressPrevNext", new[] { "AddressBase_ID" });
            DropIndex("fias.AddressBases", new[] { "PrevNext_AddressBase_ID" });
            DropTable("fias.AddressPrevNext");
            DropTable("fias.AddressBases");
        }
    }
}
