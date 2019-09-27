namespace UNS.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("integraDU")]
    public partial class IntegraDU : IntegraDUStages
    {
        //public IntegraDUStages IntegraDUStages { get; set; }

        [Description("БТИ - Тип стен")]
        [StringLength(255)]
        public string BTIWallType { get; set; }

        [Description("БТИ - Назначение")]
        [StringLength(255)]
        public string BTITarget { get; set; }

        [StringLength(255)]
        public string  Resume { get; set; } //Заключение

        [StringLength(255)]
        public string  Comment { get; set; } //Примечания

        [Description("Тип стен")]
        [StringLength(255)]
        public string WallType { get; set; } // Тип_стен

        [StringLength(255)]
        public string HouseOwner{ get; set; } //Принадлежность 
        [Description("Тип съёмки")]
        [StringLength(255)]
        public string Foto {get; set; } //Тип_съёмки {

        [Description("Контактные данные")]
        [StringLength(255)]
        public string Contacts { get; set; } // Контактные_данные 

        [Description("Руководитель ФИО")]
        [StringLength(255)]
        public string Director { get; set; } //Руководитель_ФИО 

        [Description("Должность руководителя")]
        [StringLength(255)]
        public string DirectorPosition{ get; set; } //Должность_руководителя 

        [Description("номер исх письма")]
        [StringLength(255)]
        public string LetterOutNumber{ get; set; } //Номер_исх_письма 

        [Description("Дата исх письма")]
        public DateTime? LetterOutData{ get; set; } //Дата_исх_письма 

        [Description("Наличие ответа вход")]
        [StringLength(255)]
        public string LetterIn{ get; set; } //Наличие_ответа_вход 

        [Description("Дата согласования")]
        public DateTime? CoordinationDate { get; set; }//Дата_согласования 

        [Description("Дата передачи в производство")]
        public DateTime? IntoProductionDate{ get; set; } //Дата_передачи_в_производство 

        public DateTime? ОТКАЗ { get; set; }

        [Description("ХОТЕЛКИ на МОНТАЖ")]
        [MaxLength(4000)]
        public string Istallation_Requirements { get; set; }

        [Description("Готово к монтажу")]
        public DateTime? Done_to_installation { get; set; }

        [StringLength(50)]
        public string WGS84 { get; set; }
        [StringLength(50)]
        public string EGKO_X { get; set; }
        [StringLength(50)]
        public string EGKO_Y { get; set; }
        public Organization Organization { get; set; }
        public ICollection<IntegraDU_work> IntegraDU_Works { get; set; }
        public Nullable<DateTime> PaidDate { get; set; }
    }
}
