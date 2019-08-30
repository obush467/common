namespace UNS.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("integraDU")]
    public partial class IntegraDU : IntegraDUStages
    {
        [Key]
        public IntegraDUStages IntegraDUStages { get; set; }


        [StringLength(255)]
        public string Хто { get; set; }

        [Column("БТИ - Тип стен")]
        [StringLength(255)]
        public string BTIWallType { get; set; }

        [Column("БТИ - Назначение")]
        [StringLength(255)]
        public string BTITarget { get; set; }

        [StringLength(255)]
        public string  Resume { get; set; } //Заключение

        [StringLength(255)]
        public string  Comment { get; set; } //Примечания

        [Column("Тип стен")]
        [StringLength(255)]
        public string WallType { get; set; } // Тип_стен

        [StringLength(255)]
        public string HouseOwner{ get; set; } //Принадлежность 
        [Column("Тип съёмки")]
        [StringLength(255)]
        public string Foto {get; set; } //Тип_съёмки {

        [Column("Контактные данные")]
        [StringLength(255)]
        public string Contacts { get; set; } // Контактные_данные 

        [Column("Руководитель ФИО")]
        [StringLength(255)]
        public string Director { get; set; } //Руководитель_ФИО 

        [Column("Должность руководителя")]
        [StringLength(255)]
        public string DirectorPosition{ get; set; } //Должность_руководителя 

        [Column("номер исх письма")]
        [StringLength(255)]
        public string LetterOutNumber{ get; set; } //Номер_исх_письма 

        [Column("Дата исх письма")]
        public DateTime? LetterOutData{ get; set; } //Дата_исх_письма 

        [Column("Наличие ответа вход")]
        [StringLength(255)]
        public string LetterIn{ get; set; } //Наличие_ответа_вход 

        [Column("Дата согласования")]
        public DateTime? CoordinationDate { get; set; }//Дата_согласования 

        [Column("Дата передачи в производство")]
        public DateTime? IntoProductionDate{ get; set; } //Дата_передачи_в_производство 

        public DateTime? ОТКАЗ { get; set; }

        [Column("ХОТЕЛКИ на МОНТАЖА")]
        public DateTime? ХОТЕЛКИ_на_МОНТАЖА { get; set; }

        [Column("Готово к монтажу")]
        [StringLength(255)]
        public string Готово_к_монтажу { get; set; }

        [Column("Дата выд в монтаж")]
        [StringLength(255)]
        public string Дата_выд_в_монтаж { get; set; }

        [Column("Дата монтажа")]
        [StringLength(255)]
        public string Дата_монтажа { get; set; }

        [Column("Дата подключения")]
        [StringLength(255)]
        public string Дата_подключения { get; set; }

        [StringLength(50)]
        public string WGS84 { get; set; }
        [StringLength(50)]
        public string EGKO_X { get; set; }
        [StringLength(50)]
        public string EGKO_Y { get; set; }
        public Organization Organization { get; set; }
    }
}
