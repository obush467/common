using System.Drawing.Printing;
namespace UNS.Common
{
    public class PrintPattern
    {
        public string Pattern { get; set; }
        public short Copies { get { return PrinterSettings.Copies; } set { PrinterSettings.Copies = value; } }
        public PrinterSettings PrinterSettings
        { get; set; } = new PrinterSettings() { Copies = 1, Duplex = Duplex.Default };

    }
}