namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _606 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IntegraDUStages", "Annul", c => c.DateTime());
            AddColumn("dbo.IntegraDUStages", "AnnulComment", c => c.String(maxLength: 4000));
        }

        public override void Down()
        {
            DropColumn("dbo.IntegraDUStages", "AnnulComment");
            DropColumn("dbo.IntegraDUStages", "Annul");
        }
    }
}
