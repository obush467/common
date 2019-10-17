namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _647 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
            DropColumn("fias.AddressBases", "FLATNUMBER");
            DropColumn("fias.AddressBases", "FLATTYPE");
            DropColumn("fias.AddressBases", "ROOMNUMBER");
            DropColumn("fias.AddressBases", "ROOMTYPE");
            DropColumn("fias.AddressBases", "ROOMCADNUM");
            DropColumn("fias.AddressBases", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("fias.AddressBases", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("fias.AddressBases", "ROOMCADNUM", c => c.String(maxLength: 100));
            AddColumn("fias.AddressBases", "ROOMTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "ROOMNUMBER", c => c.String(maxLength: 50));
            AddColumn("fias.AddressBases", "FLATTYPE", c => c.Int());
            AddColumn("fias.AddressBases", "FLATNUMBER", c => c.String(maxLength: 50));
            DropForeignKey("fias.AddressRoom", "ID", "fias.AddressBases");
            DropIndex("fias.AddressRoom", new[] { "ID" });
            DropTable("fias.AddressRoom");
        }
    }
}
