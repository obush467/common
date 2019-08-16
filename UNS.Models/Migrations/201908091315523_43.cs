namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("address.AdmArea", "FullName_Municipal", c => c.String(maxLength: 100));
            AddColumn("address.AdmArea", "AreaType_Municipal", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("address.AdmArea", "AreaType_Municipal");
            DropColumn("address.AdmArea", "FullName_Municipal");
        }
    }
}
