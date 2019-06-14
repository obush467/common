using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
namespace common
{
    public class Word_Operator
    {
        protected Application wordApp = new Application();
        public void PrintAkts(IEnumerable<object> akts)
        {
            foreach (var akt in akts)
            {
                wordApp.Documents.Add();
            }
        }

    }
}
