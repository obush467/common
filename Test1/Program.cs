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
                var integraDUExcelLayoutsLocal = context.IntegraDUExcelLayouts.OrderBy(o => o.Number).ToList();
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
                days.Add(DateTime.Parse("2019-06-19"));
                days.Add(DateTime.Parse("2019-06-20"));
                days.Add(DateTime.Parse("2019-06-21"));
                days.Add(DateTime.Parse("2019-06-22"));
                days.Add(DateTime.Parse("2019-06-23"));
                days.Add(DateTime.Parse("2019-06-24"));
                days.Add(DateTime.Parse("2019-06-25"));
                new Passport_Word_Operator().Create(integraDUExcelLayoutsLocal, days);
            }
        }
    }
}

