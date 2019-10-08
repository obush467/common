using AutoMapper;
using bushAddon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;
using UNS.Models.Entities.Fias;
using Excel = Microsoft.Office.Interop.Excel;

namespace UnitTestCommon
{
    [TestClass]
    public class UNSDataTest
    {
        [TestMethod]
        public void MapExcelToDU()
        {
            var application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open("C:\\Temp\\Этап 2.xlsx");
            var reestr = workbook.Sheets["Реестр"];
            IMapper mapper = (new MapperConfiguration(cfg => { cfg.AddProfile<DUExcel_Range_MapProfile>(); }).CreateMapper());
            var result = new List<IntegraDU>();
            foreach (Excel.Range row in reestr.Range["A1"].CurrentRegion.Rows)
            {
                var rowres = mapper.Map<Excel.Range, IntegraDU>(row);
                result.Add(rowres);
            }
        }

        [TestMethod]
        public void MapExcelToDU1()
        {
            var counter = 0;
            var counterLength = 100;
            var application = new Excel.Application();
            var e = new ExcelLoader(application);
            Excel.Workbook workbook = application.Workbooks.Open("C:\\Temp\\Этап 2.xlsx");
            Excel.Workbook workbook2 = application.Workbooks.Open("C:\\Temp\\Этап 21.xlsx");
            //application.Visible = false;
            var reestr = workbook.Sheets["Реестр"];
            var result = e.MapRows(reestr);
            var gr = ((IEnumerable<IntegraDU>)result).GroupBy(g => counter++ / counterLength);
            foreach (var g in gr)
            {
                e.MapRows(g.ToList(), workbook2.ActiveSheet);
                workbook2.Save();
            }
            application.Visible = true;
        }

        [TestMethod]
        public void DU_K_UD()
        {
            using (var context = new UNSModel())
            {
                var t = new DU_K_UD();
                context.Du_K_UD.Add(t);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void InsertPersons()
        {
            using (var context = new UNSModel(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                var y = new Person() { Family = "dfgdfgd", Patronymic = "sdfsdfsdfsdf ", Name = "sfsdfsdf" };
                context.Persons.Add(y);
                context.SaveChanges();
                context.Persons.Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertDocument()
        {
            using (var context = new UNSModel())
            {
                var y = new Document() { DocumentName = "sfsdfsdf" };
                context.Set<Document>().Add(y);
                context.SaveChanges();
                context.Set<Document>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertSimpLetters()
        {
            using (var context = new UNSModel())
            {
                var y = new SimplifiedLetter() { DocumentName= "sfsdfsdf",OutgoingDate=DateTime.Now,Recipient="ssdfsdf" };
                context.Set<SimplifiedLetter>().Add(y);
                context.SaveChanges();
                context.Set<SimplifiedLetter>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressBase()
        {
            using (var context = new UNSModel())
            {
                var y = new AddressBase() { ID=Guid.NewGuid(),GUID= Guid.NewGuid() };
                var y1 = new AddressBase() { ID = Guid.NewGuid(), GUID = Guid.NewGuid(),PREV=new List<AddressBase>() { y } };
                context.Set<AddressBase>().Add(y);
                context.SaveChanges();
                context.Set<AddressBase>().Remove(y);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void InsertAddressBasePrevNext()
        {
            using (var context = new UNSModel())
            {
                var prev = new AddressBase { ID = Guid.NewGuid() ,GUID =Guid.NewGuid(),CADNUM="PREV" };
                var next = new AddressBase { ID = Guid.NewGuid() ,GUID = Guid.NewGuid(), PREV =new List<AddressBase>() { prev } ,CADNUM="NEXT"};
                context.AddressBases.Add(prev);
                context.AddressBases.Add(next);
                context.SaveChanges();
                var t=prev.NEXT.Contains(next);
                var t1 = next.PREV.Contains(prev);
                if (!(t || t1)) throw new Exception("ssfsfsd");
                context.AddressBases.Remove(prev);
                context.AddressBases.Remove(next);
                context.SaveChanges();
            }
        }

    }
}

