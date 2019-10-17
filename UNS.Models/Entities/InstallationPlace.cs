using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities.Address;

namespace UNS.Models.Entities
{
    public class InstallationPlace
    {
        public Guid ID { get; set; }
        public virtual LocationBase Location { get; set; }
        public string RegistrationNumber { get; set; }
        public string InstallationPlaceType { get; set; }
        public byte[] TS { get; set; }
        public virtual TechProject TechProject { get; set; }
    }
    public class InstallationPlaceConfiguration : EntityTypeConfiguration<InstallationPlace>
    {
        public InstallationPlaceConfiguration() : base()
        {
            ToTable("InstallationPlace");
            HasKey(k => k.ID).Property(p => p.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(p => p.Location).WithMany().WillCascadeOnDelete();
            HasOptional(p=>p.TechProject).WithMany().WillCascadeOnDelete();
            Property(p => p.TS)
                .IsRowVersion()
                .IsConcurrencyToken();
        }
    }

    public class InstallationPlaceBuilding : InstallationPlace
    {
        public new LocationOneAddress Location 
        { 
            get { return (LocationOneAddress)base.Location; } 
            set { base.Location = value;} 
        }
    }

    public class InstallationPlaceBuildingConfiguration : EntityTypeConfiguration<InstallationPlaceBuilding>
    {
        public InstallationPlaceBuildingConfiguration() : base()
        {
            ToTable("InstallationPlaceBuilding");
        }
    }
    
    [Table("DuU")]
    public class DuU:InstallationPlaceBuilding
    {
        public virtual ConstructionElement ContentObject { get; set; } 
    }
    [Table("DuD")]
    public class DuD : InstallationPlaceBuilding
    {
        public virtual ConstructionElement ContentHouse { get; set; }
    }
    [Table("DuUD")]
    public class DuUD : InstallationPlaceBuilding
    {
        public virtual ConstructionElement ContentObject { get; set; }
        public virtual ConstructionElement ContentHouse { get; set; }
    }
    
    [Table("DuLB_U")]
    public class DuLB_U : DuU
    {
        public new LightBoxElement ContentObject 
        { 
            get { return (LightBoxElement)base.ContentObject; } 
            set { base.ContentObject = value; } 
        }
        public bool PhotoRelay { get; set; }
        public string TimerType { get; set; }
        public string CableChannelType { get; set; }
    }
    
    [Table("DuLB_UD")]
    public class DuLB_UD: DuUD
    {
        public new LightBoxElement ContentObject { get; set; }
        public new LightBoxElement ContentHouse { get; set; }
        public string PhotoRelayType { get; set; }
        public string TimerType { get; set; }
        public string CableChannelType { get; set; }
    }
    [Table("DuS")]
    public class DuS : DuU
    {
        public new TwoFieldElement ContentObject { get; set; }
    }
    [Table("DuLB_S")]
    public class DuLB_S: DuS
    {
        public new LightBoxTwoFieldElement ContentObject { get; set; }
        public string PhotoRelayType { get; set; }
        public string TimerType { get; set; }
        public string CableChannelType { get; set; }
    }
}
