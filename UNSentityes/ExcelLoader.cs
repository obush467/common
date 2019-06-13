using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace UNSentityes
{
    public class ExcelLoader
    {
        public List<Entityes.IntegraDUExcel> Rows { get; set; } = new List<Entityes.IntegraDUExcel>();
        public List<Entityes.integraHouses> Houses { get; set; } = new List<Entityes.integraHouses>();
        protected Excel.Application _application { get; set; }
        public ExcelLoader(Excel.Application application)
        { _application = application; }
        public void AttachRows(Excel.Worksheet worksheet)
        {
            Excel.Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Excel.Range row in wr.Rows)
            {
                Entityes.IntegraDUExcel newentity = new Entityes.IntegraDUExcel();
                newentity.Attach(row);
                Rows.Add(newentity);
            }

        }

        public void AttachHouses(Excel.Worksheet worksheet)
        {
            Excel.Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Excel.Range row in wr.Rows)
            {
                Entityes.integraHouses newentity = new Entityes.integraHouses();
                newentity.Attach(row);
                Houses.Add(newentity);
            }

        }
    }
}
