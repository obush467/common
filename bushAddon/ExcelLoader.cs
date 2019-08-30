using AutoMapper;
using bushAddon;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using UNS.Models.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace UNS.Models
{
    public class ExcelLoader
    {
        private IMapper Mapper = (new MapperConfiguration(cfg => { cfg.AddProfile<DUExcel_Range_MapProfile>(); }).CreateMapper());
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

        public List<IntegraDU> MapRows(Excel.Worksheet worksheet)
        {
            Excel.Range wr = worksheet.Range["A1"].CurrentRegion;
            var result = new List<UNS.Models.Entities.IntegraDU>();
            foreach (Excel.Range row in wr.Rows)
            {
                var t = Mapper.Map<Range, IntegraDU>(row);
               result.Add(t);
            }
            return result;

        }
    }
}
