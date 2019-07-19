namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _111 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.integraDUExcel", newName: "integraDU");                      
        }
        
        public override void Down()
        {          
            RenameTable(name: "dbo.integraDU", newName: "integraDUExcel");
        }
    }
}
