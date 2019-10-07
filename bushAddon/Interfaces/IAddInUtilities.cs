using System.Runtime.InteropServices;

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
