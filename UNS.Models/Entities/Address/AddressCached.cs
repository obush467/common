using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNS.Models.Entities.Address
{
    public class AddressCached
    {
        public Guid AddressID { get; set; }
        public Guid AddressGUID { get; set; }
        public Guid AddressPARENTGUID { get; set; }
        public string ItemAddress { get; set; }
        public string FullAddress { get; set; }
        public string ItemCategory { get; set; }
        public string ItemType { get; set; }
        public DateTime STARTDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public string REGIONCODE { get; set; }
        public string KLADRCODE { get; set; }
    }
    public class AddressCahedConfiguration : EntityTypeConfiguration<AddressCached>
    {
        public AddressCahedConfiguration() : base()
        {
            ToTable("AddressCached", "address");
            HasKey(h => h.AddressID)
                .Property(p => p.AddressID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.STARTDATE)
                .IsRequired()
                .HasColumnType("smalldatetime")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 6))); 
            Property(p => p.ENDDATE)
                .IsRequired()
                .HasColumnType("smalldatetime")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 7))); 
            Property(p => p.ItemAddress).IsRequired().HasMaxLength(200)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 5)));
            Property(p => p.ItemCategory).IsRequired().HasMaxLength(50);
            Property(p => p.ItemType).IsRequired().HasMaxLength(50);
            Property(p => p.FullAddress).IsRequired().HasMaxLength(500)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                     new IndexAnnotation(new IndexAttribute("FullAddressIndex", 2)));
            Property(p => p.AddressID)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 1)));
            Property(p => p.AddressGUID)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 3)));
            Property(p => p.AddressPARENTGUID)
                .IsOptional()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("FullAddressIndex", 4)));
            Property(p => p.REGIONCODE).IsRequired().HasMaxLength(2);
            Property(p => p.KLADRCODE).IsOptional().HasMaxLength(50);
        }

    }
}
