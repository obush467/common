namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _686 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DuLB_S", "PhotoRelayType", c => c.String());
            AddColumn("dbo.DuLB_S", "TimerType", c => c.String());
            AddColumn("dbo.DuLB_S", "CableChannelType", c => c.String());
            AddColumn("dbo.DuLB_UD", "PhotoRelayType", c => c.String());
            AddColumn("dbo.DuLB_UD", "TimerType", c => c.String());
            AddColumn("dbo.DuLB_UD", "CableChannelType", c => c.String());
            AddColumn("dbo.DuLB_U", "PhotoRelay", c => c.Boolean(nullable: false));
            AddColumn("dbo.DuLB_U", "TimerType", c => c.String());
            AddColumn("dbo.DuLB_U", "CableChannelType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DuLB_U", "CableChannelType");
            DropColumn("dbo.DuLB_U", "TimerType");
            DropColumn("dbo.DuLB_U", "PhotoRelay");
            DropColumn("dbo.DuLB_UD", "CableChannelType");
            DropColumn("dbo.DuLB_UD", "TimerType");
            DropColumn("dbo.DuLB_UD", "PhotoRelayType");
            DropColumn("dbo.DuLB_S", "CableChannelType");
            DropColumn("dbo.DuLB_S", "TimerType");
            DropColumn("dbo.DuLB_S", "PhotoRelayType");
        }
    }
}
