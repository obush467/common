namespace UNS.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _658 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "address.LocationBase",
                c => new
                    {
                        LocationBaseID = c.Guid(nullable: false, identity: true),
                        WGS84 = c.Geography(),
                        PZ90 = c.Geography(),
                        EGKO = c.Geometry(),
                        MGGT = c.Geometry(),
                        ClarificationOfLocation = c.String(maxLength: 4000,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ClarificationOfLocation",
                                    new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: ClarificationOfLocation }")
                                },
                            }),
                        AdmAreaID = c.Guid(),
                    })
                .PrimaryKey(t => t.LocationBaseID)
                .ForeignKey("address.AdmArea", t => t.AdmAreaID)
                .Index(t => t.AdmAreaID);
            
            CreateTable(
                "address.LocationManyAddress",
                c => new
                    {
                        LocationBaseID = c.Guid(nullable: false),
                        Addresses_AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LocationBaseID)
                .ForeignKey("address.LocationBase", t => t.LocationBaseID)
                .ForeignKey("address.AddressCached", t => t.Addresses_AddressID, cascadeDelete: true)
                .Index(t => t.LocationBaseID)
                .Index(t => t.Addresses_AddressID);
            
            CreateTable(
                "address.LocationOneAddress",
                c => new
                    {
                        LocationBaseID = c.Guid(nullable: false),
                        AddressID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LocationBaseID)
                .ForeignKey("address.LocationBase", t => t.LocationBaseID)
                .ForeignKey("address.AddressCached", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.LocationBaseID)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("address.LocationOneAddress", "AddressID", "address.AddressCached");
            DropForeignKey("address.LocationOneAddress", "LocationBaseID", "address.LocationBase");
            DropForeignKey("address.LocationManyAddress", "Addresses_AddressID", "address.AddressCached");
            DropForeignKey("address.LocationManyAddress", "LocationBaseID", "address.LocationBase");
            DropForeignKey("address.LocationBase", "AdmAreaID", "address.AdmArea");
            DropIndex("address.LocationOneAddress", new[] { "AddressID" });
            DropIndex("address.LocationOneAddress", new[] { "LocationBaseID" });
            DropIndex("address.LocationManyAddress", new[] { "Addresses_AddressID" });
            DropIndex("address.LocationManyAddress", new[] { "LocationBaseID" });
            DropIndex("address.LocationBase", new[] { "AdmAreaID" });
            DropTable("address.LocationOneAddress");
            DropTable("address.LocationManyAddress");
            DropTable("address.LocationBase",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "ClarificationOfLocation",
                        new Dictionary<string, object>
                        {
                            { "ClarificationOfLocation", "IndexAnnotation: { Name: ClarificationOfLocation }" },
                        }
                    },
                });
        }
    }
}
