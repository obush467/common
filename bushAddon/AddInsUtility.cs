using System.Runtime.InteropServices;
using bushAddon;
using Microsoft.Office.Interop.Excel;

[ComVisible(true)]
public interface IAddInUtilities
{
    void ImportData();
    void PrintAkts();
}

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.None)]
public class AddInUtilities : IAddInUtilities
{
    // This method tries to write a string to cell A1 in the active worksheet.
    public void ImportData()
    {
        Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet as Worksheet;

        if (activeWorksheet != null)
        {
            Range range1 = activeWorksheet.get_Range("A1", System.Type.Missing);
            range1.Value2 = "This is my data";
        }
    }

    public void PrintAkts()
    {
        throw new System.NotImplementedException();
    }
}