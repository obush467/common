namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class _38 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("address.HouseFull", "GeoData", c => c.Geography());
            AddColumn("address.HouseFull", "KLADR", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "ADR_TYPE", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "StoreysCount", c => c.Int());
            AddColumn("address.HouseFull", "WallMaterial", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Purpose", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Class", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Type", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "Attribute", c => c.String(maxLength: 50));
            AddColumn("address.HouseFull", "TotalArea", c => c.Single());
            //AlterColumn("address.HouseFull", "Address", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("address.HouseFull", "Address", c => c.String());
            DropColumn("address.HouseFull", "TotalArea");
            DropColumn("address.HouseFull", "Attribute");
            DropColumn("address.HouseFull", "Type");
            DropColumn("address.HouseFull", "Class");
            DropColumn("address.HouseFull", "Purpose");
            DropColumn("address.HouseFull", "WallMaterial");
            DropColumn("address.HouseFull", "StoreysCount");
            DropColumn("address.HouseFull", "ADR_TYPE");
            DropColumn("address.HouseFull", "KLADR");
            DropColumn("address.HouseFull", "GeoData");
        }
    }
}
