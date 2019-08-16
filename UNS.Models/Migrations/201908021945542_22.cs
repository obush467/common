namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DirectorPositions", newName: "DirectorPositions11");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DirectorPositions11", newName: "DirectorPositions");
        }
    }
}
