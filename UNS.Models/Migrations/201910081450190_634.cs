namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _634 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.AddressHouse",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressHouse", "ID", "fias.AddressBases");
            DropIndex("fias.AddressHouse", new[] { "ID" });
            DropTable("fias.AddressHouse");
        }
    }
}
