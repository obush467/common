namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _576 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations");
            //DropIndex("dbo.OwnerRawAddress", new[] { "Organization_Id" });
            //DropIndex("dbo.OwnerRawAddress", new[] { "Organization_ID" });
            //AlterColumn("dbo.OwnerRawAddress", "Organization_Id", c => c.Guid(nullable: false));
            //CreateIndex("dbo.OwnerRawAddress", "Organization_Id");
            //AddForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_Id" });
            AlterColumn("dbo.OwnerRawAddress", "Organization_Id", c => c.Guid());
            CreateIndex("dbo.OwnerRawAddress", "Organization_ID");
            CreateIndex("dbo.OwnerRawAddress", "Organization_Id");
            AddForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations", "Id");
        }
    }
}
