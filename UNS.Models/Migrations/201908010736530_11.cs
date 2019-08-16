namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FaxItems",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.FaxItems");
        }
    }
}
