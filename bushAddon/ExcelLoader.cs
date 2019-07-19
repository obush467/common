using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace UNS.Models
{
    public class ExcelLoader
    {
        public List<Entities.IntegraDUExcel> Rows { get; set; } = new List<Entities.IntegraDUExcel>();
        public List<Entities.IntegraHouses> Houses { get; set; } = new List<Entities.IntegraHouses>();
        protected Excel.Application _application { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public ExcelLoader(Excel.Application application)
        { _application = application; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        public void AttachRows(Excel.Worksheet worksheet)
        {
            Excel.Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Excel.Range row in wr.Rows)
            {
                Entities.IntegraDUExcel newentity = new Entities.IntegraDUExcel();
                newentity.Attach(row);
                Rows.Add(newentity);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        public void AttachHouses(Excel.Worksheet worksheet)
        {
            Excel.Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Excel.Range row in wr.Rows)
            {
                Entities.IntegraHouses newentity = new Entities.IntegraHouses();
                newentity.Attach(row);
                Houses.Add(newentity);
            }

        }
    }
}
