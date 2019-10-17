namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _645 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "fias.AddressStatuses",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        OPERSTATUS = c.Int(),
                        REGIONCODE = c.String(maxLength: 2),
                        LIVESTATUS = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("fias.AddressStatuses");
        }
    }
}
