namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class _614 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.integraDU_works", "DateVerificationFoto", c => c.DateTime());
            AddColumn("dbo.integraDU_works", "DateLightCheck", c => c.DateTime());
            AddColumn("dbo.integraDU_works", "DateLightCheckReceiptFoto", c => c.DateTime());
            AddColumn("dbo.integraDU_works", "DateLightCheckVerificationFoto", c => c.DateTime());
            AddColumn("dbo.integraDU_works", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.integraDU_works", "DatVerificationFoto");
        }

        public override void Down()
        {
            AddColumn("dbo.integraDU_works", "DatVerificationFoto", c => c.DateTime());
            DropColumn("dbo.integraDU_works", "Discriminator");
            DropColumn("dbo.integraDU_works", "DateLightCheckVerificationFoto");
            DropColumn("dbo.integraDU_works", "DateLightCheckReceiptFoto");
            DropColumn("dbo.integraDU_works", "DateLightCheck");
            DropColumn("dbo.integraDU_works", "DateVerificationFoto");
        }
    }
}
