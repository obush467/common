namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _689 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("fias.AddressObjects", "UPDATEDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.AddressObjects", "STARTDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.AddressObjects", "ENDDATE", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("fias.AddressObjects", "ENDDATE", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("fias.AddressObjects", "STARTDATE", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("fias.AddressObjects", "UPDATEDATE", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
