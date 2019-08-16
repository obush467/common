namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea");
            DropPrimaryKey("address.AdmArea");
            AddColumn("address.AdmArea", "AdmAreaId", c => c.Guid(nullable: false, identity: true));
            AddColumn("address.AdmArea", "ParentAdmAreaId", c => c.Guid());
            AddColumn("address.AdmArea", "LatinName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("address.AdmArea", "OKATO", c => c.String(nullable: false, maxLength: 20));
            AddColumn("address.AdmArea", "Type", c => c.String(maxLength: 20));
            AddColumn("address.AdmArea", "Kod", c => c.String(maxLength: 20));
            AlterColumn("address.AdmArea", "FullName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("address.AdmArea", "ShortName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("address.AdmArea", "AreaType", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("address.AdmArea", "AdmAreaId");
            AddForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea", "AdmAreaId", cascadeDelete: true);
            DropColumn("address.AdmArea", "Id");
            DropColumn("address.AdmArea", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("address.AdmArea", "ParentId", c => c.Guid());
            AddColumn("address.AdmArea", "Id", c => c.Guid(nullable: false, identity: true));
            DropForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea");
            DropPrimaryKey("address.AdmArea");
            AlterColumn("address.AdmArea", "AreaType", c => c.String(nullable: false));
            AlterColumn("address.AdmArea", "ShortName", c => c.String(nullable: false));
            AlterColumn("address.AdmArea", "FullName", c => c.String(nullable: false));
            DropColumn("address.AdmArea", "Kod");
            DropColumn("address.AdmArea", "Type");
            DropColumn("address.AdmArea", "OKATO");
            DropColumn("address.AdmArea", "LatinName");
            DropColumn("address.AdmArea", "ParentAdmAreaId");
            DropColumn("address.AdmArea", "AdmAreaId");
            AddPrimaryKey("address.AdmArea", "Id");
            AddForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea", "Id", cascadeDelete: true);
        }
    }
}
