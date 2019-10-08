namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _635 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AddressBase_PrevNext", newSchema: "fias");
        }
        
        public override void Down()
        {
            MoveTable(name: "fias.AddressBase_PrevNext", newSchema: "dbo");
        }
    }
}
