using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace bushAddon.Interfaces
{
    [ComVisible(true)]
    public interface IAddInUtilities
    {
        void ImportData();
        void PrintAkts();
        void PrintDislocations();
        void BTIWallType();
    }
}
