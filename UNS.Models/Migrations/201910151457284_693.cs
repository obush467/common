namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _693 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("address.AddressCachedObjectBuilding", "WallMaterial", c => c.String(maxLength: 255));
            AlterColumn("address.AddressCachedObjectBuilding", "Purpose", c => c.String(maxLength: 255));
            AlterColumn("address.AddressCachedObjectBuilding", "Class", c => c.String(maxLength: 255));
            AlterColumn("address.AddressCachedObjectBuilding", "Type", c => c.String(maxLength: 255));
            AlterColumn("address.AddressCachedObjectBuilding", "Attribute", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("address.AddressCachedObjectBuilding", "Attribute", c => c.String(maxLength: 50));
            AlterColumn("address.AddressCachedObjectBuilding", "Type", c => c.String(maxLength: 50));
            AlterColumn("address.AddressCachedObjectBuilding", "Class", c => c.String(maxLength: 50));
            AlterColumn("address.AddressCachedObjectBuilding", "Purpose", c => c.String(maxLength: 50));
            AlterColumn("address.AddressCachedObjectBuilding", "WallMaterial", c => c.String(maxLength: 50));
        }
    }
}
