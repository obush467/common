namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _640 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "fias.AddressBases", newName: "AddressAOs");
            DropIndex("fias.AddressAOs", new[] { "AddressCode_ID" });
            DropIndex("fias.AddressAOs", new[] { "AddressStatus_ID" });
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
                .PrimaryKey(t => t.ID)
                .Index(t => t.AddressCode_ID)
                .Index(t => t.AddressStatus_ID);
            
            AlterColumn("fias.AddressAOs", "AOLEVEL", c => c.Int(nullable: false));
            CreateIndex("fias.AddressAOs", "ID");
            AddForeignKey("fias.AddressAOs", "ID", "fias.AddressBases", "ID");
            DropColumn("fias.AddressAOs", "GUID");
            DropColumn("fias.AddressAOs", "PARENTGUID");
            DropColumn("fias.AddressAOs", "NORMDOC");
            DropColumn("fias.AddressAOs", "UPDATEDATE");
            DropColumn("fias.AddressAOs", "STARTDATE");
            DropColumn("fias.AddressAOs", "ENDDATE");
            DropColumn("fias.AddressAOs", "POSTALCODE");
            DropColumn("fias.AddressAOs", "CADNUM");
            DropColumn("fias.AddressAOs", "Discriminator");
            DropColumn("fias.AddressAOs", "AddressCode_ID");
            DropColumn("fias.AddressAOs", "AddressStatus_ID");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressAOs", "AddressStatus_ID", c => c.Guid());
            AddColumn("fias.AddressAOs", "AddressCode_ID", c => c.Guid());
            AddColumn("fias.AddressAOs", "Discriminator", c => c.String(maxLength: 128));
            AddColumn("fias.AddressAOs", "CADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressAOs", "POSTALCODE", c => c.String(maxLength: 6));
            AddColumn("fias.AddressAOs", "ENDDATE", c => c.DateTime());
            AddColumn("fias.AddressAOs", "STARTDATE", c => c.DateTime());
            AddColumn("fias.AddressAOs", "UPDATEDATE", c => c.DateTime());
            AddColumn("fias.AddressAOs", "NORMDOC", c => c.Guid());
            AddColumn("fias.AddressAOs", "PARENTGUID", c => c.Guid());
            AddColumn("fias.AddressAOs", "GUID", c => c.Guid(nullable: false));
            DropForeignKey("fias.AddressAOs", "ID", "fias.AddressBases");
            DropIndex("fias.AddressAOs", new[] { "ID" });
            DropIndex("fias.AddressBases", new[] { "AddressStatus_ID" });
            DropIndex("fias.AddressBases", new[] { "AddressCode_ID" });
            AlterColumn("fias.AddressAOs", "AOLEVEL", c => c.Int());
            DropTable("fias.AddressBases");
            CreateIndex("fias.AddressAOs", "AddressStatus_ID");
            CreateIndex("fias.AddressAOs", "AddressCode_ID");
            RenameTable(name: "fias.AddressAOs", newName: "AddressBases");
        }
    }
}
