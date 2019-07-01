using bushAddon;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UNSData.Entities;
using UNSData.Models;

[ComVisible(true)]
public interface IAddInUtilities
{
    void ImportData();
    void PrintAkts();
    void BTIWallType();
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
        throw new NotImplementedException();
    }

    public void BTIWallType()
    {
        using (UNSModel context = new UNSModel())
        {
            EnableCalculations(false);
            List<IntegraDUExcel> integraDUs = ReestrSheet();
            integraDUs.Remove(integraDUs[0]);
            List<IntegraDUExcel> hasUNOMs =
                (from integraDU in integraDUs
                 where integraDU.BTIwallType == null
                 select integraDU).ToList();
            foreach (IntegraDUExcel destRow in hasUNOMs)
            {
                try
                {
                    int unom = int.Parse(destRow.UNOM.ToString());
                    var query = new List<BTI2018_UNOM_Result>();// (from bti in context.BTI2018_UNOM(unom) select bti).ToList();
                    if (query.Any())
                    {
                        destRow.BTIwallType = query.FirstOrDefault().Material;
                        destRow.BTIdestination = query.FirstOrDefault().Purpose;
                    }
                }
                catch (Exception)
                { }
            }
            EnableCalculations(true);
        }
    }
    private List<IntegraDUExcel> ReestrSheet()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Реестр"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        UNSData.ExcelLoader _excelLoader = new UNSData.ExcelLoader(Globals.ThisAddIn.Application);
        _excelLoader.AttachRows(WSSource);
        return (from row in _excelLoader.Rows
                where row.UNIU != null &&
                      row.UNOM != null
                      && !string.IsNullOrEmpty(row.UNOM.ToString())
                      && !string.IsNullOrEmpty(row.UNIU.ToString())
                orderby row.AddressO, row.AddressH
                select row).ToList();
    }
    private List<IntegraHouses> HouseSheet()
    {
        Worksheet WSSource = Globals.ThisAddIn.Application.Sheets["Дома"];
        EnableCalculations(false);
        Globals.ThisAddIn.Application.CopyObjectsWithCells = true;
        UNSData.ExcelLoader _excelLoader = new UNSData.ExcelLoader(Globals.ThisAddIn.Application);
        _excelLoader.AttachHouses(WSSource);
        return (from row in _excelLoader.Houses
                where row.UNOM != null
                      && !string.IsNullOrEmpty(row.UNOM.ToString())
                orderby row.Address
                select row).ToList();
    }

    protected void EnableCalculations(bool Enable)
    {
        foreach (Worksheet sh in Globals.ThisAddIn.Application.Sheets)
        {
            sh.EnableCalculation = Enable;
        }
    }
}