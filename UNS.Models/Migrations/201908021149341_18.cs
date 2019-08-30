namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailItems", "Email", c => c.String(maxLength: 50));
            AddColumn("dbo.FaxItems", "Fax", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhoneItems", "Phone", c => c.String(maxLength: 50));
        }

        public override void Down()
        {
            AlterColumn("dbo.PhoneItems", "Phone", c => c.String());
            AlterColumn("dbo.FaxItems", "Fax", c => c.String());
            AlterColumn("dbo.EmailItems", "Email", c => c.String());
        }
    }
}
