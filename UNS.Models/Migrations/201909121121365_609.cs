namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _609 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.integraDU", "ХОТЕЛКИ на МОНТАЖА", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.integraDU", "ХОТЕЛКИ на МОНТАЖА", c => c.DateTime());
        }
    }
}
