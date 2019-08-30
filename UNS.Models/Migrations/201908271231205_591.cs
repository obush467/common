namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _591 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.integraDU", "Заключение", "Resume");
            RenameColumn("dbo.integraDU", "Примечания", "Comment");
            RenameColumn("dbo.integraDU", "Принадлежность", "HouseOwner");
            AlterColumn("dbo.IntegraDUStages", "UNOM", c => c.Int());
        }
        
        public override void Down()
        {
            AddColumn("dbo.integraDU", "Принадлежность", c => c.String(maxLength: 255));
            AddColumn("dbo.integraDU", "Примечания", c => c.String(maxLength: 255));
            AddColumn("dbo.integraDU", "Заключение", c => c.String(maxLength: 255));
            AlterColumn("dbo.IntegraDUStages", "UNOM", c => c.Int(nullable: false));
            DropColumn("dbo.integraDU", "HouseOwner");
            DropColumn("dbo.integraDU", "Comment");
            DropColumn("dbo.integraDU", "Resume");
        }
    }
}
