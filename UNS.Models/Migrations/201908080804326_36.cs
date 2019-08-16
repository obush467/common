namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _36 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("address.AdmArea", "Kod", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("address.AdmArea", "Kod", c => c.String(maxLength: 20));
        }
    }
}
