namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _590 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            AddForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes");
            AddForeignKey("dbo.PersonPositions", "PositionType_Id", "dbo.PersonPositionTypes", "Id");
        }
    }
}
