namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _628 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AddressBases", newSchema: "fias");
        }
        
        public override void Down()
        {
            MoveTable(name: "fias.AddressBases", newSchema: "dbo");
        }
    }
}
