using System.Drawing.Printing;

namespace UNS.Common.Interfaces
{
    internal interface IOut
    {
        void Print();
        void Print(PrinterSettings printerSettings);
    }
}