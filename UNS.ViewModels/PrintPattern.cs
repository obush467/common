using System.Drawing.Printing;
namespace UNS.ViewsModels
{
    public class PrintPattern
    {
        public string Pattern { get; set; }
        public short Copies { get { return PrinterSettings.Copies; } set { PrinterSettings.Copies = value; } }
        public PrinterSettings PrinterSettings
        { get; } = new PrinterSettings() { Copies = 1, Duplex = Duplex.Default };

    }
}