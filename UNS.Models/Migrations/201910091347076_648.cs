namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _648 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.AddressStead",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        NUMBER = c.String(maxLength: 120),
                        COUNTER = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("fias.AddressBases", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("fias.AddressStead", "ID", "fias.AddressBases");
            DropIndex("fias.AddressStead", new[] { "ID" });
            DropTable("fias.AddressStead");
        }
    }
}
