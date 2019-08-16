namespace UNS.Models.Entities.Address
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("address.AdmArea")]
    public class AdmArea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AdmAreaId { get; set; }
        public Guid? ParentAdmAreaId { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string ShortName { get; set; }
        [MaxLength(100)]
        public string LatinName { get; set; }
        [Required]
        [MaxLength(20)]
        public string OKATO { get; set; }
        [MaxLength(50)]
        public string AreaType { get; set; }
        [MaxLength(20)]
        public string Type { get; set; }
        [MaxLength(8)]
        public string Kod { get; set; }
        [MaxLength(100)]
        public string FullName_Municipal { get; set; }
        [MaxLength(50)]
        public string AreaType_Municipal { get; set; }
    }
}