using System.Drawing.Printing;

namespace common.Interfaces
{
    internal interface IOut
    {
        void Print();
        void Print(PrinterSettings printerSettings);
    }
}