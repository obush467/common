namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _644 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.AddressCodes",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        IFNSFL = c.String(maxLength: 4),
                        TERRIFNSFL = c.String(maxLength: 4),
                        OKATO = c.String(maxLength: 11),
                        OKTMO = c.String(maxLength: 11),
                        DIVTYPE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("fias.AddressCodes");
        }
    }
}
