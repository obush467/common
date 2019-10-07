using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UNS.Models;

namespace UnitTestCommon
{
    [TestClass]
    public class PassportOperator_Test
    {
        [TestMethod]
        public void Print()
        {
            using (var context = new UNSModel())
            {
                context.Database.CommandTimeout = 180;
                //var integraDUExcelLayouts = context.IntegraDU.Where(w => w.Stage == "18006").OrderBy(o => o.Number).Select(s=>(PassportContent)s).ToList();
                var days = new List<DateTime>()
                {
                    DateTime.Parse("2019-08-01"),
                    DateTime.Parse("2019-08-02"),
                    DateTime.Parse("2019-08-05"),
                    DateTime.Parse("2019-08-06"),
                    DateTime.Parse("2019-08-07"),
                    DateTime.Parse("2019-08-08"),
                    DateTime.Parse("2019-08-09")
                };
                //new Passport_Word_Operator().Create(integraDUExcelLayouts);
            }
        }
    }
}
