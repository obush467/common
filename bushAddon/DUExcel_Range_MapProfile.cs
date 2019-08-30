using AutoMapper;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models.Entities;

namespace bushAddon
{
    public class IntConverter : IValueConverter<Range, int?>
    {
        public int? Convert(Range source, ResolutionContext context)
        {
            int result;
            if (source != null && source.Value2 != null)

            {
                int.TryParse(source.Value2, out result);
                return result;
            }
            else
            { return null; }
        }

    }

    public static class RangeConverter<T>
    {
        public static T Convert(Range source)
        {
            if (source != null && source.Value2 != null)

            {
                try
                {
                    return source.Value2;
                }
                catch (Exception)
                { return default(T); }
            }
            else
            { return default(T); }
        }
        public static int ConvertValue(Range source)
        {
            return source.Value2;
        }
       /* public static DateTime ConvertValue<T>(Range source) where ff:DateTime
        {
            double d = double.Parse(source.Value2);
            return DateTime.FromOADate(d);
        }*/

    }


        public class DateTimeTypeConverter : ITypeConverter<Range, IntegraDU>
    {
        public IntegraDU Convert(Range source, IntegraDU destination, ResolutionContext context)
        {
            if (destination == null) destination = new IntegraDU();
            try
            {
                destination.Number = RangeConverter<int?>.Convert(source.Cells[1, 1]); //Номер
                destination.DUType = RangeConverter<string>.Convert(source.Cells[1, 2]);// Тип информационного указателя
                destination.Okrug = RangeConverter<string>.Convert(source.Cells[1, 3]); // Округ
                destination.District= RangeConverter<string>.Convert(source.Cells[1, 4]); // Район
                destination.AddressObject = RangeConverter<string>.Convert(source.Cells[1, 5]); // Улица
                destination.AddressHouse = RangeConverter<string>.Convert(source.Cells[1, 6]); // Номер дома
                destination.ContentObject = RangeConverter<string>.Convert(source.Cells[1, 7]); // Информационное содержание - Улица
                destination.ContentHouse = RangeConverter<string>.Convert(source.Cells[1, 8]); // Информационное содержание - Номер дома
                destination.InstallationStatus = RangeConverter<string>.Convert(source.Cells[1, 9]); // Статус установки
                destination.UNOM= RangeConverter<int?>.Convert(source.Cells[1, 10]); // UNOM
                destination.UNIU = RangeConverter<string>.Convert(source.Cells[1, 11]); // Уникальный номер
                                                               //destination..Person,s=>s.MapFrom(m=>source.Cells[1, 12].Value2; // Хто
                destination.BTIWallType = RangeConverter<string>.Convert(source.Cells[1, 13]); // БТИ - Тип стен
                destination.BTITarget = RangeConverter<string>.Convert(source.Cells[1, 14]); // БТИ - Назначение
                destination.Resume = RangeConverter<string>.Convert(source.Cells[1, 15]); // Заключение
                destination.Comment = RangeConverter<string>.Convert(source.Cells[1, 16]); // Примечания
                destination.WallType = RangeConverter<string>.Convert(source.Cells[1, 17]); // Тип стен
                destination.HouseOwner = RangeConverter<string>.Convert(source.Cells[1, 18]); // Принадлежность
                destination.Foto = RangeConverter<string>.Convert(source.Cells[1, 19]); // Тип съёмки
                destination.Contacts = RangeConverter<string>.Convert(source.Cells[1, 20]); // Контактные данные
                destination.Director = RangeConverter<string>.Convert(source.Cells[1, 21]); // Руководитель
                destination.DirectorPosition = RangeConverter<string>.Convert(source.Cells[1, 22]); // Должность руководителя
                destination.LetterOutNumber = RangeConverter<string>.Convert(source.Cells[1, 23]); // номер исх письма
                destination.LetterOutData = RangeConverter<DateTime?>.Convert(source.Cells[1, 24]); // Дата исх письма
                destination.LetterIn = RangeConverter<string>.Convert(source.Cells[1, 25]); // Наличие ответа вход
                destination.CoordinationDate = RangeConverter<DateTime?>.Convert(source.Cells[1, 26]); // Дата согласования
                destination.IntoProductionDate = RangeConverter<DateTime?>.Convert(source.Cells[1, 27]); // Дата передачи в производство
            }
            catch (Exception e)
            { }
            return destination;
        }
    }
    public class DUExcel_Range_MapProfile : Profile
    {
        public DUExcel_Range_MapProfile() : base()
        {
            var excelvalues = new object[30];
            CreateMap<Microsoft.Office.Interop.Excel.Range, IntegraDU>()
            .ConvertUsing(new DateTimeTypeConverter())
            /*.ForMember(d => d.Number, s => s.MapFrom(m => m.Cells[1, 2])) // Тип информационного указателя
            .ForMember(d => d.Okrug, s => s.MapFrom(m => m.Cells[1, 3])) // Округ
            //_District,s=>s.MapFrom(m=>m.Cells[1, 4]; // Район
            .ForMember(d => d.AddressObject, s => s.MapFrom(m => m.Cells[1, 5])) // Улица
            .ForMember(d => d.AddressHouse, s => s.MapFrom(m => m.Cells[1, 6])) // Номер дома
            .ForMember(d => d.ContentObject, s => s.MapFrom(m => m.Cells[1, 7])) // Информационное содержание - Улица
            .ForMember(d => d.ContentHouse, s => s.MapFrom(m => m.Cells[1, 8])) // Информационное содержание - Номер дома
            .ForMember(d => d.InstallationStatus, s => s.MapFrom(m => m.Cells[1, 9])) // Статус установки
            .ForMember(d => d.UNOM, s => s.MapFrom(m => m.Cells[1, 10])) // UNOM
            .ForMember(d => d.UNIU, s => s.MapFrom(m => m.Cells[1, 11])) // Уникальный номер
            //.ForMember(d => d.Person,s=>s.MapFrom(m=>m.Cells[1, 12])) // Хто
            .ForMember(d => d.BTIWallType, s => s.MapFrom(m => m.Cells[1, 13])) // БТИ - Тип стен
            .ForMember(d => d.BTITarget, s => s.MapFrom(m => m.Cells[1, 14])) // БТИ - Назначение
            .ForMember(d => d.Resume, s => s.MapFrom(m => m.Cells[1, 15])) // Заключение
            .ForMember(d => d.Comment, s => s.MapFrom(m => m.Cells[1, 16])) // Примечания
            .ForMember(d => d.WallType, s => s.MapFrom(m => m.Cells[1, 17])) // Тип стен
            .ForMember(d => d.HouseOwner, s => s.MapFrom(m => m.Cells[1, 18])) // Принадлежность
            .ForMember(d => d.Foto, s => s.MapFrom(m => m.Cells[1, 19])) // Тип съёмки
            .ForMember(d => d.Contacts, s => s.MapFrom(m => m.Cells[1, 20])) // Контактные данные
            .ForMember(d => d.Director, s => s.MapFrom(m => m.Cells[1, 21])) // Руководитель
            .ForMember(d => d.DirectorPosition, s => s.MapFrom(m => m.Cells[1, 22])) // Должность руководителя
            .ForMember(d => d.LetterOutNumber, s => s.MapFrom(m => m.Cells[1, 23])) // номер исх письма
            .ForMember(d => d.LetterOutData, s => s.MapFrom(m => m.Cells[1, 24])) // Дата исх письма
            .ForMember(d => d.LetterIn, s => s.MapFrom(m => m.Cells[1, 25])) // Наличие ответа вход
            .ForMember(d => d.CoordinationDate, s => s.MapFrom(m => m.Cells[1, 26])) // Дата согласования
            .ForMember(d => d.IntoProductionDate, s => s.MapFrom(m => m.Cells[1, 27])) // Дата передачи в производство*/
            ;
        }
    }
}
