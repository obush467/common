using AutoMapper;
using bushAddon;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using UNS.Common.Entities;
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

            worksheet.EnableCalculation = false;
            Range wr = worksheet.Range["2:3002"];//.CurrentRegion;
            var result = new List<IntegraDU>();
            foreach (Range row in wr.Rows)
            {
                var t = Mapper.Map<Range, IntegraDU>(row);
               result.Add(t);
            }
            worksheet.EnableCalculation =true;
            return result;

        }

        public void  MapRows(List<IntegraDU> sources,Worksheet destination)
        {
            Range wr = destination.Range["2:3002"];
            destination.EnableCalculation = false;
            var l1 = new List<dynamic>();
            foreach (Range row in wr.Rows)
            { l1.Add(new { UNIU=row.Cells[1, 1].Value2 ,row=row}); }
            var l2 = from l11 in l1
                     join source in sources
                     on l11.UNIU equals source.UNIU
                     select new { l11.UNIU, l11.row, source }; 
            foreach (var row in l2)
            {
                var t = Mapper.Map<IntegraDU, Range>(row.source,row.row);
            }
            destination.EnableCalculation = true;
        }
    }
}
