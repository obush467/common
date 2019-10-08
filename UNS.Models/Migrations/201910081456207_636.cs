namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _636 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
            DropColumn("fias.AddressBases", "FORMALNAME");
            DropColumn("fias.AddressBases", "AUTOCODE");
            DropColumn("fias.AddressBases", "AREACODE");
            DropColumn("fias.AddressBases", "CITYCODE");
            DropColumn("fias.AddressBases", "CTARCODE");
            DropColumn("fias.AddressBases", "PLACECODE");
            DropColumn("fias.AddressBases", "STREETCODE");
            DropColumn("fias.AddressBases", "EXTRCODE");
            DropColumn("fias.AddressBases", "SEXTCODE");
            DropColumn("fias.AddressBases", "OFFNAME");
            DropColumn("fias.AddressBases", "SHORTNAME");
            DropColumn("fias.AddressBases", "AOLEVEL");
            DropColumn("fias.AddressBases", "CODE");
            DropColumn("fias.AddressBases", "PLAINCODE");
            DropColumn("fias.AddressBases", "ACTSTATUS");
            DropColumn("fias.AddressBases", "CENTSTATUS");
            DropColumn("fias.AddressBases", "CURRSTATUS");
            DropColumn("fias.AddressBases", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("fias.AddressBases", "CURRSTATUS", c => c.Int());
            AddColumn("fias.AddressBases", "CENTSTATUS", c => c.Int());
            AddColumn("fias.AddressBases", "ACTSTATUS", c => c.Int());
            AddColumn("fias.AddressBases", "PLAINCODE", c => c.String(maxLength: 15));
            AddColumn("fias.AddressBases", "CODE", c => c.String(maxLength: 17));
            AddColumn("fias.AddressBases", "AOLEVEL", c => c.Int());
            AddColumn("fias.AddressBases", "SHORTNAME", c => c.String(maxLength: 10));
            AddColumn("fias.AddressBases", "OFFNAME", c => c.String(maxLength: 120));
            AddColumn("fias.AddressBases", "SEXTCODE", c => c.String(maxLength: 3));
            AddColumn("fias.AddressBases", "EXTRCODE", c => c.String(maxLength: 4));
            AddColumn("fias.AddressBases", "STREETCODE", c => c.String(maxLength: 4));
            AddColumn("fias.AddressBases", "PLACECODE", c => c.String(maxLength: 3));
            AddColumn("fias.AddressBases", "CTARCODE", c => c.String(maxLength: 3));
            AddColumn("fias.AddressBases", "CITYCODE", c => c.String(maxLength: 3));
            AddColumn("fias.AddressBases", "AREACODE", c => c.String(maxLength: 3));
            AddColumn("fias.AddressBases", "AUTOCODE", c => c.String(maxLength: 1));
            AddColumn("fias.AddressBases", "FORMALNAME", c => c.String(maxLength: 120));
            DropForeignKey("fias.AddressAOs", "ID", "fias.AddressBases");
            DropIndex("fias.AddressAOs", new[] { "ID" });
            DropTable("fias.AddressAOs");
        }
    }
}
