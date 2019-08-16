using UNS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UNS.Models.Entities;
using UNS.Models;
using Logger;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UNSModel("data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                context.Database.CommandTimeout = 180;
                var integraDUExcelLayouts = new List<IntegraDUExcelLayout>();
                var integraDUExcelLayoutsLocal = context.IntegraDUExcelLayouts.Where(w=>w.Stage=="Этап 3").OrderBy(o => o.Number).ToList();
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-Д").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-УД").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-С").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-У").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-М-УД").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-М-У").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                foreach (var i in integraDUExcelLayouts)
                {
                    i.ContentObjectFullPath = Path.ChangeExtension(i.ContentObjectFullPath, "png");
                    i.ContentHouseFullPath = Path.ChangeExtension(i.ContentHouseFullPath, "png");
                }
                //(new Akt_Word_Operator()).Create(integraDUExcelLayouts);
                var days = new List<DateTime>();
                days.Add(DateTime.Parse("2019-08-01"));
                days.Add(DateTime.Parse("2019-08-02"));
                days.Add(DateTime.Parse("2019-08-05"));
                days.Add(DateTime.Parse("2019-08-06"));
                days.Add(DateTime.Parse("2019-08-07"));
                days.Add(DateTime.Parse("2019-08-08"));
                days.Add(DateTime.Parse("2019-08-09"));
                new Passport_Word_Operator().Create(integraDUExcelLayoutsLocal, days);
            }
        }
    }
}

