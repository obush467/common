using AutoMapper;
using bushAddon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UNS.Models;
using UNS.Models.Entities;
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
                context.RRR.Add(t);
                context.SaveChanges();
            }
        }
        [TestMethod]
        public void DU_K_UD1()
        {
            using (var context = new UNSModel(@"data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
               context.Configuration.AutoDetectChangesEnabled = true; //var t = context.AddressBases.FirstOrDefault() ;
                var y = context.RawAddresses.FirstOrDefault();
                y.Source=y.Source+y.Source;                
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void DU_K_UD2()
        {
            using (var context = new UNSModel())
            {
                /*var t = new InstallationPlace() { Location = new UNS.Models.Entities.Address.Location() { Address = new AddressBase() } };
                context.InstallationPlace.Add(t);
                context.SaveChanges();*/
            }
        }

    }
}

