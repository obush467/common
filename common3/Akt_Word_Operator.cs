using common.Office;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNSData;
using UNSData.Entities;

namespace common
{
    public class Akt_Word_Operator : Word_Operator
    {
        protected DirectoryInfo _templateDir = new DirectoryInfo("\\\\NAS-D4\\integra\\Шаблоны\\");
        protected DirectoryInfo _rootdir = new DirectoryInfo("c:\\Паспорта\\");
        public Akt_Word_Operator(DirectoryInfo templateDir, DirectoryInfo rootdir)
        {
            _rootdir = rootdir;
            _templateDir = templateDir;
        }
        public void CreateAkts(IEnumerable<IntegraDUExcelLayout> akts)
        {
            foreach (IntegraDUExcelLayout integraDUExcelLayout in akts)
            {
                CreateAkt(integraDUExcelLayout);
            }
        }

        private void CreateAkt(IntegraDUExcelLayout integraDUExcelLayout)
        {
            throw new NotImplementedException();
        }

        public static void PrintAkts(IEnumerable<IntegraDUExcelLayout> akts)
        {
            foreach (var akt in akts)
            {
                PrintAkt(akt);
            }
        }

        private static void PrintAkt(IntegraDUExcelLayout akt)
        {
            throw new NotImplementedException();
        }


    }
}

