namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _42 : DbMigration
    {
        public override void Up()
        {
            DropColumn("address.HouseFull", "UNOM");
            DropColumn("address.HouseFull", "ADR_TYPE");
            DropColumn("address.HouseFull", "StoreysCount");
            DropColumn("address.HouseFull", "WallMaterial");
            DropColumn("address.HouseFull", "Purpose");
            DropColumn("address.HouseFull", "Class");
            DropColumn("address.HouseFull", "Type");
            DropColumn("address.HouseFull", "Attribute");
            DropColumn("address.HouseFull", "TotalArea");
        }
        
        public override void Down()
        {
            AddColumn("address.HouseFull", "TotalArea", c => c.Single());
            AddColumn("address.HouseFull", "Attribute", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Type", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Class", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Purpose", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "WallMaterial", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "StoreysCount", c => c.Int());
            AddColumn("address.HouseFull", "ADR_TYPE", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "UNOM", c => c.Int());
        }
    }
}
