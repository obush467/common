namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _592 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea");
            DropIndex("address.HouseFull", new[] { "AdmAreaId" });
            AlterColumn("address.HouseFull", "AdmAreaId", c => c.Guid(nullable: true));
            CreateIndex("address.HouseFull", "AdmAreaId");
            AddForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea", "AdmAreaId");
        }

        public override void Down()
        {
            DropForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea");
            DropIndex("address.HouseFull", new[] { "AdmAreaId" });
            AlterColumn("address.HouseFull", "AdmAreaId", c => c.Guid(nullable: false));
            CreateIndex("address.HouseFull", "AdmAreaId");
            AddForeignKey("address.HouseFull", "AdmAreaId", "address.AdmArea", "AdmAreaId", cascadeDelete: true);
        }
    }
}
