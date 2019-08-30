namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _575 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations");
            // DropIndex("dbo.OwnerRawAddress", new[] { "Organization_ID" });
            //AlterColumn("dbo.OwnerRawAddress", "Organization_Id", c => c.Guid());
            //CreateIndex("dbo.OwnerRawAddress", "Organization_Id");
            // CreateIndex("dbo.OwnerRawAddress", "Organization_ID");
            // AddForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.OwnerRawAddress", "Organization_Id", "dbo.Organizations");
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_ID" });
            DropIndex("dbo.OwnerRawAddress", new[] { "Organization_Id" });
            AlterColumn("dbo.OwnerRawAddress", "Organization_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.OwnerRawAddress", "Organization_ID");
            AddForeignKey("dbo.OwnerRawAddress", "Organization_ID", "dbo.Organizations", "Id", cascadeDelete: true);
        }
    }
}
