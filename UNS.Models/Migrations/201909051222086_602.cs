namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _602 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressObject1s", "ID", "fias.AddressBases");
            DropIndex("fias.AddressObject1s", new[] { "ID" });
            DropTable("fias.AddressObject1s");
        }
    }
}
