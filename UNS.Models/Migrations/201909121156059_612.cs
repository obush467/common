namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _612 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.integraDU", "Done_to_installation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.integraDU", "Done_to_installation", c => c.DateTime());
        }
    }
}
