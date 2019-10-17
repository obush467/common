namespace UNS.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class _659 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("address.LocationBase", "ClarificationOfLocation", c => c.String(maxLength: 4000,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ClarificationOfLocation",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: ClarificationOfLocation }", newValue: null)
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("address.LocationBase", "ClarificationOfLocation", c => c.String(maxLength: 4000,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ClarificationOfLocation",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: ClarificationOfLocation }")
                    },
                }));
        }
    }
}
