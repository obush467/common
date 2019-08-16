using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace UNS.Models.Entities
{
    public class Organization
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual OrganizationType OrganizationType { get; set; }
        [MaxLength(300)]
        public string ShortName { get; set; }
        [MaxLength(1000)]
        public string FullName { get; set; }
        [MaxLength(30)]
        public string OGRN { get; set; }
        [MaxLength(12)]
        public string INN { get; set; }
        [MaxLength(9)]
        public string KPP { get; set; }
        /// <summary>
        /// адресе места нахождения постоянно действующего исполнительного органа юридического лица
        /// </summary>
        [MaxLength(1000)]
        public string UrAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MaxLength(10)]
        public string OKPO { get; set; }
        [MaxLength(11)]
        public string OKATO { get; set; }
        [MaxLength(11)]
        public string OKTMTO { get; set; }
        [MaxLength(7)]
        public string OKOGU { get; set; }
        [MaxLength(5)]
        public string OKOPF { get; set; }
        [MaxLength(6)]
        public string UNK { get; set; }
        [MaxLength(100)]
        public string OKVED { get; set; }
        [MaxLength(50)]
        public string OGS { get; set; }
        [MaxLength(3)]
        public string OKFS { get; set; }
        [MaxLength(11)]
        public string OKTMO { get; set; }
        public virtual ICollection<PersonPosition> PersonPositions { get; set; }
        //public virtual ICollection<DirectorPosition> DirectorPositions { get {return PersonPositions } }// = new List<DirectorPosition>();
        //public ICollection<AccountantGeneralPosition> AccountantGeneralPositions { get; set; }
        public DbGeography GeoData { get; set; }
        [MaxLength(255)]
        public string WebSite { get; set; }
        public ICollection<FaxItem> FaxItems { get; set; }
        public ICollection<EmailItem> EmailItems { get; set; }
        public ICollection<PhoneItem> PhoneItems { get; set; }
        public ICollection<OwnerRawAddress> OwnerRawAddresses{ get; set; }

        public Organization()    { }
    }
}
