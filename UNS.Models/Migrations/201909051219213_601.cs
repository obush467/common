namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _601 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.AddressCodes",
                c => new
                {
                    AddressBase_ID = c.Guid(nullable: false),
                    IFNSFL = c.String(maxLength: 4),
                    TERRIFNSFL = c.String(maxLength: 4),
                    OKATO = c.String(maxLength: 11),
                    OKTMO = c.String(maxLength: 11),
                    DIVTYPE = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AddressBase_ID)
                .ForeignKey("fias.AddressBases", t => t.AddressBase_ID)
                .Index(t => t.AddressBase_ID);

            CreateTable(
                "fias.Stead1",
                c => new
                {
                    ID = c.Guid(nullable: false),
                    NUMBER = c.String(maxLength: 120),
                    COUNTER = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);

            AddColumn("fias.AddressBases", "AddressCode_AddressBase_ID", c => c.Guid());
            CreateIndex("fias.AddressBases", "AddressCode_AddressBase_ID");
            AddForeignKey("fias.AddressBases", "AddressCode_AddressBase_ID", "fias.AddressCodes", "AddressBase_ID");
        }

        public override void Down()
        {
            DropForeignKey("fias.Stead1", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressBases", "AddressCode_AddressBase_ID", "fias.AddressCodes");
            DropForeignKey("fias.AddressCodes", "AddressBase_ID", "fias.AddressBases");
            DropIndex("fias.Stead1", new[] { "ID" });
            DropIndex("fias.AddressCodes", new[] { "AddressBase_ID" });
            DropIndex("fias.AddressBases", new[] { "AddressCode_AddressBase_ID" });
            DropColumn("fias.AddressBases", "AddressCode_AddressBase_ID");
            DropTable("fias.Stead1");
            DropTable("fias.AddressCodes");
        }
    }
}
