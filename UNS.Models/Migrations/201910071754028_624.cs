namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _624 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("address.Location", "Address_ID", "fias.AddressBases");
            DropIndex("address.Location", new[] { "Address_ID" });
            DropColumn("address.Location", "Address_ID");
        }
        
        public override void Down()
        {
            AddColumn("address.Location", "Address_ID", c => c.Guid());
            CreateIndex("address.Location", "Address_ID");
            AddForeignKey("address.Location", "Address_ID", "fias.AddressBases", "ID");
        }
    }
}
