using common;
using common.Office;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNSData.Models;
using Microsoft.Office.Interop.Word;
using static common.Word_Operator;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UNSModel("data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {

                context.Database.CommandTimeout = 180;
                var integraDUExcelLayouts = context.IntegraDUExcelLayouts.Where(w => w.DUType == "ДУ-К-Д").Take(10).OrderByDescending(o => o.Number).ToList();
                (new Passport_Word_Operator()).Create(integraDUExcelLayouts);
            }
        }
    }
}

