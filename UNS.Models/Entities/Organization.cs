using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Models.Entities
{
    public class Organization
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public virtual List<DirectorPosition> DirectorPosition { get; set; }// = new List<DirectorPosition>();
    }
}
