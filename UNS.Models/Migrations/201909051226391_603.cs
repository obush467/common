namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _603 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.Room1",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("fias.Room1", "ID", "fias.AddressBases");
            DropIndex("fias.Room1", new[] { "ID" });
            DropTable("fias.Room1");
        }
    }
}
