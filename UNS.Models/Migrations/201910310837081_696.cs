namespace UNS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _696 : DbMigration
    {
        public override void Up()
        {
            /*AlterColumn("fias.Del_House", "UPDATEDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.Del_NormativeDocument", "DOCDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.House", "UPDATEDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.House", "STARTDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.House", "ENDDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.NormativeDocument", "DOCDATE", c => c.DateTime(storeType: "date"));
            AlterColumn("fias.Room", "UPDATEDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.Room", "STARTDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.Room", "ENDDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.Stead", "UPDATEDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.Stead", "STARTDATE", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("fias.Stead", "ENDDATE", c => c.DateTime(nullable: false, storeType: "date"));*/
        }
        
        public override void Down()
        {
            AlterColumn("fias.Stead", "ENDDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.Stead", "STARTDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.Stead", "UPDATEDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.Room", "ENDDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.Room", "STARTDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.Room", "UPDATEDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.NormativeDocument", "DOCDATE", c => c.DateTime());
            AlterColumn("fias.House", "ENDDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.House", "STARTDATE", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            AlterColumn("fias.House", "UPDATEDATE", c => c.DateTime(storeType: "smalldatetime"));
            AlterColumn("fias.Del_NormativeDocument", "DOCDATE", c => c.DateTime(storeType: "smalldatetime"));
            AlterColumn("fias.Del_House", "UPDATEDATE", c => c.DateTime(storeType: "smalldatetime"));
        }
    }
}
