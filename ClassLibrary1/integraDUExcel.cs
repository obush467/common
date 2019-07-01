namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("integraDUExcel")]
    public partial class integraDUExcel : integraDUStages
    {
        [ForeignKey("integraDUStages")]
        public Guid ID { get; set; }

        [StringLength(255)]
        public string Хто { get; set; }

        [Column("БТИ - Тип стен")]
        [StringLength(255)]
        public string БТИ___Тип_стен { get; set; }

        [Column("БТИ - Назначение")]
        [StringLength(255)]
        public string БТИ___Назначение { get; set; }

        [StringLength(255)]
        public string Заключение { get; set; }

        [StringLength(255)]
        public string Примечания { get; set; }

        [Column("Тип стен")]
        [StringLength(255)]
        public string Тип_стен { get; set; }

        [StringLength(255)]
        public string Принадлежность { get; set; }

        [Column("Тип съёмки")]
        [StringLength(255)]
        public string Тип_съёмки { get; set; }

        [Column("Контактные данные")]
        [StringLength(255)]
        public string Контактные_данные { get; set; }

        [Column("Руководитель ФИО")]
        [StringLength(255)]
        public string Руководитель_ФИО { get; set; }

        [Column("Должность руководителя")]
        [StringLength(255)]
        public string Должность_руководителя { get; set; }

        [Column("номер исх письма")]
        [StringLength(255)]
        public string номер_исх_письма { get; set; }

        [Column("Дата исх письма")]
        public DateTime? Дата_исх_письма { get; set; }

        [Column("Наличие ответа вход")]
        [StringLength(255)]
        public string Наличие_ответа_вход { get; set; }

        [Column("Дата согласования")]
        public DateTime? Дата_согласования { get; set; }

        [Column("Дата передачи в производство")]
        public DateTime? Дата_передачи_в_производство { get; set; }

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

        [StringLength(255)]
        public string F34 { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SysStartTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime SysEndTime { get; set; }

        public virtual integraDUStages integraDUStages { get; set; }
    }
}
