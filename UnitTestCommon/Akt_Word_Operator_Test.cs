using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using UNS.Common;
using UNS.Models;

namespace UnitTestCommon
{
    [TestClass]
    public class Akt_Word_Operator_Test
    {
        [TestMethod]
        public void CreateAllAkts()
        {
            using (var context = new UNSModel("data source=BUSHMAKIN;initial catalog=UNS;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                context.Database.CommandTimeout = 180;
                var integraDUExcelLayouts = context.DUTechnicalCertificates.Where(w => w.Stage == "18006").OrderBy(o => o.Number).ToList();
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-Д").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-УД").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-С").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                //integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-К-У").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-М-УД").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                // integraDUExcelLayouts.Add(integraDUExcelLayoutsLocal.Where(w => w.DUType == "ДУ-М-У").Take(10).OrderByDescending(o => o.Number).FirstOrDefault());
                (new Akt_Word_Operator()).Create(integraDUExcelLayouts);
            }
        }
    }
}
