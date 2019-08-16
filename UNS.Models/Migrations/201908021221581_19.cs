namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonPositionTypes", "PositionType_Genitive", c => c.String(maxLength: 200));
            AddColumn("dbo.PersonPositionTypes", "PositionType_Dative", c => c.String(maxLength: 200));
            AddColumn("dbo.PersonPositionTypes", "PositionType_Accusative", c => c.String(maxLength: 200));
            AddColumn("dbo.PersonPositionTypes", "PositionType_Ablative", c => c.String(maxLength: 200));
            AddColumn("dbo.PersonPositionTypes", "PositionType_Prepositional", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonPositionTypes", "PositionType_Prepositional");
            DropColumn("dbo.PersonPositionTypes", "PositionType_Ablative");
            DropColumn("dbo.PersonPositionTypes", "PositionType_Accusative");
            DropColumn("dbo.PersonPositionTypes", "PositionType_Dative");
            DropColumn("dbo.PersonPositionTypes", "PositionType_Genitive");
        }
    }
}
