using UNS.Common;
using UNS.Common.Interfaces;
using UNS.Common.Office;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNS.Models;
using Excel=Microsoft.Office.Interop.Excel;
using AutoMapper;
using UNS.Models.Entities;
using bushAddon;

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
                var rowres = mapper.Map<Excel.Range,IntegraDU>(row);
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
            var result=e.MapRows(reestr);
            var gr = ((IEnumerable<IntegraDU>)result).GroupBy(g => counter++ / counterLength);
            foreach (var g in gr)
            {
                e.MapRows(g.ToList(), workbook2.ActiveSheet);
                workbook2.Save();
            }
            application.Visible = true;
        }

    }
    }

