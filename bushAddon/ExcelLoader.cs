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
        public List<IntegraDUExcel> Rows { get; set; } = new List<IntegraDUExcel>();
        public List<IntegraHouses> Houses { get; set; } = new List<IntegraHouses>();
        protected Application _application { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public ExcelLoader(Application application)
        { _application = application; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        public void AttachRows(Worksheet worksheet)
        {
            Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Range row in wr.Rows)
            {
                IntegraDUExcel newentity = new IntegraDUExcel();
                newentity.Attach(row);
                Rows.Add(newentity);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worksheet"></param>
        public void AttachHouses(Worksheet worksheet)
        {
            Range wr = worksheet.Range["A1"].CurrentRegion;
            foreach (Range row in wr.Rows)
            {
                IntegraHouses newentity = new IntegraHouses();
                newentity.Attach(row);
                Houses.Add(newentity);
            }

        }

        public List<IntegraDU> MapRows(Worksheet worksheet)
        {
            Range wr = worksheet.Range["A1"].CurrentRegion;
            var result = new List<IntegraDU>();
            foreach (Range row in wr.Rows)
            {
                var t = Mapper.Map<Range, IntegraDU>(row);
               result.Add(t);
            }
            return result;

        }
    }
}
