namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _625 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("address.Location", "AdmArea_AdmAreaId", "address.AdmArea");
            DropIndex("address.Location", new[] { "AdmArea_AdmAreaId" });
            DropColumn("address.Location", "AdmArea_AdmAreaId");
        }
        
        public override void Down()
        {
            AddColumn("address.Location", "AdmArea_AdmAreaId", c => c.Guid());
            CreateIndex("address.Location", "AdmArea_AdmAreaId");
            AddForeignKey("address.Location", "AdmArea_AdmAreaId", "address.AdmArea", "AdmAreaId");
        }
    }
}
