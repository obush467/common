namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _639 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressCacheds",
                c => new
                    {
                        AddressID = c.Guid(nullable: false),
                        AddressGUID = c.Guid(nullable: false),
                        AddressPARENTGUID = c.Guid(nullable: false),
                        ItemAddress = c.String(),
                        FullAddress = c.String(),
                        ItemCategory = c.String(),
                        ItemType = c.String(),
                        STARTDATE = c.DateTime(nullable: false),
                        ENDDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "COUNTER", c => c.Int());
            AddColumn("fias.AddressBases", "NUMBER", c => c.String(maxLength: 120));
            AddColumn("fias.AddressBases", "ROOMCADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressBases", "ROOMTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "ROOMNUMBER", c => c.String(maxLength: 50));
            AddColumn("fias.AddressBases", "FLATTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "FLATNUMBER", c => c.String(maxLength: 50));
            DropForeignKey("fias.AddressStead", "ID", "fias.AddressBases");
            DropForeignKey("fias.AddressRoom", "ID", "fias.AddressBases");
            DropIndex("fias.AddressStead", new[] { "ID" });
            DropIndex("fias.AddressRoom", new[] { "ID" });
            AlterColumn("fias.AddressBases", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("fias.AddressStead");
            DropTable("fias.AddressRoom");
            DropTable("dbo.AddressCacheds");
        }
    }
}
