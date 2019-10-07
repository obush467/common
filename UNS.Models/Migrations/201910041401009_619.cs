namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _619 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("fias.AddressPrevNext", "NEXTID", "fias.AddressBases");
            DropForeignKey("fias.AddressPrevNext", "PREVID", "fias.AddressBases");
            DropForeignKey("fias.AddressBases", "PrevNext_AddressBase_ID", "fias.AddressPrevNext");
            DropIndex("fias.AddressBases", new[] { "PrevNext_AddressBase_ID" });
            DropIndex("fias.AddressPrevNext", new[] { "PREVID" });
            DropIndex("fias.AddressPrevNext", new[] { "NEXTID" });
            CreateTable(
                "dbo.AddressBase_PrevNext",
                c => new
                    {
                        PREVID = c.Guid(nullable: false),
                        NEXTID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PREVID, t.NEXTID })
                .ForeignKey("fias.AddressBases", t => t.PREVID)
                .ForeignKey("fias.AddressBases", t => t.NEXTID)
                .Index(t => t.PREVID)
                .Index(t => t.NEXTID);            
            AddColumn("fias.AddressBases", "AddressBase_ID", c => c.Guid());
            CreateIndex("fias.AddressBases", "AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases", "ID");
            DropColumn("fias.AddressBases", "PrevNext_AddressBase_ID");
            DropColumn("fias.AddressPrevNext", "PREVID");
            DropColumn("fias.AddressPrevNext", "NEXTID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressPrevNext", "NEXTID", c => c.Guid());
            AddColumn("fias.AddressPrevNext", "PREVID", c => c.Guid());
            AddColumn("fias.AddressBases", "PrevNext_AddressBase_ID", c => c.Guid());
            DropForeignKey("dbo.AddressBase_PrevNext", "NEXTID", "fias.AddressBases");
            DropForeignKey("dbo.AddressBase_PrevNext", "PREVID", "fias.AddressBases");
            DropForeignKey("fias.AddressBases", "AddressBase_ID", "fias.AddressBases");
            DropIndex("dbo.AddressBase_PrevNext", new[] { "NEXTID" });
            DropIndex("dbo.AddressBase_PrevNext", new[] { "PREVID" });
            DropIndex("fias.AddressBases", new[] { "AddressBase_ID" });
            DropColumn("fias.AddressBases", "AddressBase_ID");
            DropTable("dbo.AddressBase_PrevNext");
            CreateIndex("fias.AddressPrevNext", "NEXTID");
            CreateIndex("fias.AddressPrevNext", "PREVID");
            CreateIndex("fias.AddressBases", "PrevNext_AddressBase_ID");
            AddForeignKey("fias.AddressBases", "PrevNext_AddressBase_ID", "fias.AddressPrevNext", "AddressBase_ID");
            AddForeignKey("fias.AddressPrevNext", "PREVID", "fias.AddressBases", "ID");
            AddForeignKey("fias.AddressPrevNext", "NEXTID", "fias.AddressBases", "ID");
        }
    }
}
