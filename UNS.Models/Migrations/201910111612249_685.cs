namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _685 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ConstractionElements", newName: "ConstructionElements");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ConstructionElements", newName: "ConstractionElements");
        }
    }
}
