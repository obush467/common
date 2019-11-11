using AutoMapper;
using Microsoft.Office.Interop.Excel;
using System;
using UNS.Models.Entities;

namespace UNS.Common
{
    public class IntConverter : IValueConverter<Range, int?>
    {
        public int? Convert(Range source, ResolutionContext context)
        {
            if (source != null && source.Value2 != null)

            {
                int.TryParse(source.Value2, out int result);
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
                { return default; }
            }
            else
            { return default; }
        }
        public static int ConvertValue(Range source)
        {
            return source.Value2;
        }
    }

    public static class ToRangeConverter<T>
    {
        public static object Convert(T source)
        {
            if (source != null)

            {
                try
                {
                    return source.ToString();
                }
                catch (Exception)
                { return default(T); }
            }
            else
            { return default(T); }
        }
        public static object ConvertValue(int? source)
        {
            return source;
        }
        public static object ConvertValue(DateTime source)
        {
            return source.ToOADate();
        }

    }


    public class ExcelToDUTypeConverter : ITypeConverter<Range, IntegraDU>
    {
        public DateTime? ToDateTime(object date)
        {
            try
            {
                return (date != null) ? (DateTime?)DateTime.FromOADate((double)date) : null;
            }
            catch (Exception)
            { return null; }

        }

        public int? ToInt(object date)
        {
            try
            {
                return (date != null) ? (int?)int.Parse(date.ToString()) : null;
            }
            catch (Exception)
            { return null; }
        }
        public IntegraDU Convert(Range source, IntegraDU destination, ResolutionContext context)
        {
            if (destination == null) destination = new IntegraDU();
            try
            {
                dynamic[,] excelArray = source.Value2 as dynamic[,];
                destination.UNIU = excelArray[1, 1];
                destination.Number = ToInt(excelArray[1, 2]); //Номер
                destination.DUType = excelArray[1, 3];// Тип информационного указателя
                destination.Okrug = excelArray[1, 4]; // Округ
                destination.District = excelArray[1, 5]; // Район
                destination.AddressObject = excelArray[1, 6]; // Улица
                destination.AddressHouse = excelArray[1, 7]; // Номер дома
                destination.ContentObject = excelArray[1, 8]; // Информационное содержание - Улица
                destination.ContentHouse = excelArray[1, 9]; // Информационное содержание - Номер дома
                destination.InstallationStatus = excelArray[1, 10]; // Статус установки
                destination.UNOM = ToInt(excelArray[1, 11]); // UNOM                
                destination.BTIWallType = excelArray[1, 12]; // БТИ - Тип стен
                destination.BTITarget = excelArray[1, 13]; // БТИ - Назначение
                destination.Resume = excelArray[1, 14]; // Заключение
                destination.Comment = excelArray[1, 15]; // Примечания
                destination.HouseOwner = excelArray[1, 16]; // Принадлежность
                destination.Contacts = excelArray[1, 17]; // Контактные данные
                destination.Director = excelArray[1, 18]; // Руководитель
                destination.DirectorPosition = excelArray[1, 19]; // Должность руководителя
                destination.LetterOutNumber = excelArray[1, 20]; // номер исх письма
                destination.LetterOutData = ToDateTime(excelArray[1, 21]); // Дата исх письма
                destination.LetterIn = excelArray[1, 22]; // Наличие ответа вход
                destination.CoordinationDate = ToDateTime(excelArray[1, 23]);// Дата согласования
                destination.IntoProductionDate = ToDateTime(excelArray[1, 24]); // Дата передачи в производство
                destination.Refusal = excelArray[1, 25];//ОТКАЗ 
                destination.IntoProductionDate = ToDateTime(excelArray[1, 26]); ;//ХОТЕЛКИ на МОНТАЖ   
                destination.IntoProductionDate = ToDateTime(excelArray[1, 27]); ;//ДУ изготовлен
            }
            catch (Exception e)
            { Logger.Logger.Error(e.Message); }
            return destination;
        }
    }

    public class DUToExcelTypeConverter : ITypeConverter<IntegraDU, Range>
    {
        public Range Convert(IntegraDU source, Range destination, ResolutionContext context)
        {
            try
            {
                dynamic[,] excelArray = destination.Cells.Value2 as dynamic[,];
                excelArray[1, 1] = ToRangeConverter<string>.Convert(source.UNIU);// Уникальный номер 
                excelArray[1, 2] = ToRangeConverter<int?>.Convert(source.Number);//Номер
                excelArray[1, 3] = ToRangeConverter<string>.Convert(source.DUType);// Тип информационного указателя
                excelArray[1, 4] = source.Okrug; // Округ
                excelArray[1, 5] = source.District; // Район
                excelArray[1, 6] = ToRangeConverter<string>.Convert(source.AddressObject); // Улица
                excelArray[1, 7] = ToRangeConverter<string>.Convert(source.AddressHouse); // Номер дома
                excelArray[1, 8] = ToRangeConverter<string>.Convert(source.ContentObject); // Информационное содержание - Улица
                excelArray[1, 9] = ToRangeConverter<string>.Convert(source.ContentHouse); // Информационное содержание - Номер дома
                excelArray[1, 10] = ToRangeConverter<string>.Convert(source.InstallationStatus); // Статус установки
                excelArray[1, 11] = ToRangeConverter<int?>.Convert(source.UNOM); // UNOM
                excelArray[1, 12] = ToRangeConverter<string>.Convert(source.BTIWallType); // БТИ - Тип стен
                excelArray[1, 13] = ToRangeConverter<string>.Convert(source.BTITarget); // БТИ - Назначение
                excelArray[1, 14] = ToRangeConverter<string>.Convert(source.Resume); // Заключение
                excelArray[1, 15] = ToRangeConverter<string>.Convert(source.Comment); // Примечания
                excelArray[1, 16] = ToRangeConverter<string>.Convert(source.HouseOwner); // Принадлежность              
                excelArray[1, 17] = ToRangeConverter<string>.Convert(source.Contacts); // Контактные данные
                excelArray[1, 18] = ToRangeConverter<string>.Convert(source.Director); // Руководитель
                excelArray[1, 19] = ToRangeConverter<string>.Convert(source.DirectorPosition); // Должность руководителя
                excelArray[1, 20] = ToRangeConverter<string>.Convert(source.LetterOutNumber); // номер исх письма
                excelArray[1, 21] = ToRangeConverter<DateTime?>.Convert(source.LetterOutData); // Дата исх письма
                excelArray[1, 22] = ToRangeConverter<string>.Convert(source.LetterIn); // Наличие ответа вход
                excelArray[1, 23] = ToRangeConverter<DateTime?>.Convert(source.CoordinationDate); // Дата согласования
                excelArray[1, 24] = ToRangeConverter<DateTime?>.Convert(source.IntoProductionDate); // Дата передачи в производство                
                excelArray[1, 25] = ToRangeConverter<string>.Convert(source.Refusal); // ОТКАЗ
                excelArray[1, 26] = ToRangeConverter<string>.Convert(source.Istallation_Requirements); // ХОТЕЛКИ на МОНТАЖ
                excelArray[1, 27] = ToRangeConverter<DateTime?>.Convert(source.Done_to_installation); // ДУ изготовлен
                destination.Value2 = excelArray;
            }
            catch (Exception e)
            { Logger.Logger.Error(e.Message); }
            return destination;
        }
    }
    public class DUExcel_Range_MapProfile : Profile
    {
        public DUExcel_Range_MapProfile() : base()
        {
            CreateMap<Range, IntegraDU>()
            .ConvertUsing(new ExcelToDUTypeConverter());
            CreateMap<IntegraDU, Range>()
            .ConvertUsing(new DUToExcelTypeConverter());
        }
    }
}
