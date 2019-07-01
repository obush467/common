using Microsoft.Office.Interop.Excel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNSData.Entities
{
    public class IntegraHouses
    {
        private Range _Address; // Адрес
        private Range _UNOM; // UNOM
        private Range _Street; // Улица
        private Range _House; // дом
        private Range _Organisation; // Организация
        private Range _Person; // ФИО
        private Range _PersonPosition; // Должнность
        private Range _Telephone; // Телефон
        private Range _email; // Почта
        private Range _District; // Почта
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public object Email { get => _email.Value2; set => _email.Value2 = value; }
        public object UNOM { get => _UNOM.Value2; set => _UNOM.Value2 = value; }
        public object House { get => _House.Value2; set => _House.Value2 = value; }
        public object Organisation { get => _Organisation.Value2; set => _Organisation.Value2 = value; }
        public object Address { get => _Address.Value2; set => _Address.Value2 = value; }
        public object Street { get => _Street.Value2; set => _Street.Value2 = value; }
        public object PersonPosition { get => _PersonPosition.Value2; set => _PersonPosition.Value2 = value; }
        public object Telephone { get => _Telephone.Value2; set => _Telephone.Value2 = value; }
        public object Person { get => _Person.Value2; set => _Person.Value2 = value; }
        public object District { get => _District.Value2; set => _District.Value2 = value; }
        public void Attach(Range range)
        {
            _Address = range.Cells[1, 1]; // Адрес
            _UNOM = range.Cells[1, 2]; // UNOM
            _Street = range.Cells[1, 3]; // Улица
            _House = range.Cells[1, 4]; // дом
            _District = range.Cells[1, 5]; // дом
            _Organisation = range.Cells[1, 6]; // Организация
            _Person = range.Cells[1, 7]; // ФИО
            _PersonPosition = range.Cells[1, 8]; // Должнность
            _Telephone = range.Cells[1, 9]; // Телефон
            _email = range.Cells[1, 10]; // Почта
        }
    }
}
