namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _615 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.integraDU", "PaidDate", c => c.DateTime());
            DropColumn("dbo.integraDU", "Хто");
        }
        
        public override void Down()
        {
            AddColumn("dbo.integraDU", "Хто", c => c.String(maxLength: 255));
            DropColumn("dbo.integraDU", "PaidDate");
        }
    }
}
