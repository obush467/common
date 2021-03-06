﻿using Microsoft.Office.Interop.Excel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNS.Common.Entities
{
    public class IntegraDUExcel
    {
        private Range _Number;
        private Range _DUtype; // Тип информационного указателя
        private Range _AdmArea; // Округ
        private Range _District; // Район
        private Range _AddressO; // Улица
        private Range _AddressH; // Номер дома
        private Range _ContentO; // Информационное содержание - Улица
        private Range _ContentH; // Информационное содержание - Номер дома
        private Range _InstallStatus; // Статус установки
        private Range _UNOM; // UNOM
        private Range _UNIU; // Уникальный номер
        private Range _BTIwallType; // БТИ - Тип стен
        private Range _BTIdestination; // БТИ - Назначение
        private Range _Resume; // Заключение
        private Range _Comment; // Примечания
        private Range _HouseOwner; // Принадлежность
        private Range _Contacts; // Контактные данные
        private Range _Director; // Руководитель
        private Range _DirectorPosition; // Должность руководителя
        private Range _LetterOutNumber; // номер исх письма
        private Range _LetterOutData; // Дата исх письма
        private Range _LetterIn; // Наличие ответа вход
        private Range _CoordinationDate; // Дата согласования
        private Range _IntoProductionDate; // Дата передачи в производство
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [DisplayName("№")]
        public object Number { get { return _Number.Value2; } set { _Number.Value2 = value; } }
        [DisplayName("Тип информационного указателя")]
        public object DUtype { get { return _DUtype.Value2; } set { _DUtype.Value2 = value; } }    //	
        public object AdmArea { get { return _AdmArea.Value2; } set { _AdmArea.Value2 = value; } }   //	
        [DisplayName("Район")]
        public object District { get { return _District.Value2; } set { _District.Value2 = value; } }  //	
        [DisplayName("Улица")]
        public object AddressObject { get { return _AddressO.Value2; } set { _AddressO.Value2 = value; } }  //	
        [DisplayName("Номер дома")]
        public object AddressHouse { get { return _AddressH.Value2; } set { _AddressH.Value2 = value; } }  //	
        [DisplayName("Информационное содержание - Улица")]
        public object ContentObject { get { return _ContentO.Value2; } set { _ContentO.Value2 = value; } }  //	
        [DisplayName("Информационное содержание - Номер дома")]
        public object ContentHouse { get { return _ContentH.Value2; } set { _ContentH.Value2 = value; } }  //	
        [DisplayName("Статус установки")]
        public object InstallStatus
        {
            get { return _InstallStatus.Value2; }
            set
            {
                _InstallStatus.Interior.Color = 65535;
                _InstallStatus.Value2 = value;
            }
        } //	
        [DisplayName("UNOM")]
        public object UNOM
        {
            get { return _UNOM.Value2; }
            set
            {
                _UNOM.Value2 = value;
                _UNOM.Interior.Color = 65535;
            }
        }  //	
        [DisplayName("Уникальный номер")]
        public object UNIU { get { return _UNIU.Value2; } set { _UNIU.Value2 = value; } }  //	

        [DisplayName("БТИ - Тип стен")]
        public object BTIwallType { get { return _BTIwallType.Value2; } set { _BTIwallType.Value2 = value; } }   //	
        [DisplayName("БТИ - Назначение")]
        public object BTIdestination { get { return _BTIdestination.Value2; } set { _BTIdestination.Value2 = value; } }    //	
        [DisplayName("Заключение")]
        public object Resume { get { return _Resume.Value2; } set { _Resume.Value2 = value; } }    //	
        [DisplayName("Примечания")]
        public object Comment { get { return _Comment.Value2; } set { _Comment.Value2 = value; } }   //	

        [DisplayName("Принадлежность")]
        public object HouseOwner { get { return _HouseOwner.Value2; } set { _HouseOwner.Value2 = value; _HouseOwner.Interior.Color = 65535; } }    //	

        [DisplayName("Контактные данные")]
        public object Contacts { get { return _Contacts.Value2; } set { _Contacts.Value2 = value; } }  //	
        [DisplayName("Руководитель")]
        public object Director { get { return _Director.Value2; } set { _Director.Value2 = value; } }  //	
        [DisplayName("Должность руководителя")]
        public object DirectorPosition { get { return _DirectorPosition.Value2; } set { _DirectorPosition.Value2 = value; } }  //	
        [DisplayName("номер исх письма")]
        public object LetterOutNumber { get { return _LetterOutNumber.Value2; } set { _LetterOutNumber.Value2 = value; } }   //	
        [DisplayName("Дата исх письма")]
        public object LetterOutData { get { return _LetterOutData.Value2; } set { _LetterOutData.Value2 = value; } } //	
        [DisplayName("Наличие ответа вход")]
        public object LetterIn { get { return _LetterIn.Value2; } set { _LetterIn.Value2 = value; } }  //	
        [DisplayName("Дата согласования")]
        public object CoordinationDate { get { return _CoordinationDate.Value2; } set { _CoordinationDate.Value2 = value; } }  //	
        [DisplayName("Дата передачи в производство")]
        public object IntoProductionDate { get { return _IntoProductionDate.Value2; } set { _IntoProductionDate.Value2 = value; } }	//
        public void Attach(Range range)
        {
            if (range.Rows.Count == 1 /*&& range.Columns.Count >= 26*/)
            {
                _UNIU = range.Cells[1, 1]; // Уникальный номер
                _Number = range.Cells[1, 2];
                _DUtype = range.Cells[1, 3]; // Тип информационного указателя
                _AdmArea = range.Cells[1, 4]; // Округ
                _District = range.Cells[1, 5]; // Район
                _AddressO = range.Cells[1, 6]; // Улица
                _AddressH = range.Cells[1, 7]; // Номер дома
                _ContentO = range.Cells[1, 8]; // Информационное содержание - Улица
                _ContentH = range.Cells[1, 9]; // Информационное содержание - Номер дома
                _InstallStatus = range.Cells[1, 10]; // Статус установки
                _UNOM = range.Cells[1, 11]; // UNOM
                _BTIwallType = range.Cells[1, 12]; // БТИ - Тип стен
                _BTIdestination = range.Cells[1, 13]; // БТИ - Назначение
                _Resume = range.Cells[1, 14]; // Заключение
                _Comment = range.Cells[1, 15]; // Примечания               
                _HouseOwner = range.Cells[1, 16]; // Принадлежность               
                _Contacts = range.Cells[1, 17]; // Контактные данные
                _Director = range.Cells[1, 18]; // Руководитель
                _DirectorPosition = range.Cells[1, 19]; // Должность руководителя
                _LetterOutNumber = range.Cells[1, 20]; // номер исх письма
                _LetterOutData = range.Cells[1, 21]; // Дата исх письма
                _LetterIn = range.Cells[1, 22]; // Наличие ответа вход
                _CoordinationDate = range.Cells[1, 23]; // Дата согласования
                _IntoProductionDate = range.Cells[1, 24]; // Дата передачи в производство
            }
        }


    }
}
