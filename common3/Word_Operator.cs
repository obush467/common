using common.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using UNSData.Entities;

namespace common
{
    public class Word_Operator
    {
        //public Application wordApp = new Application();

        public delegate Table CreateFunc(Range range, string duType = null);

        public void CreateBookmarkedDocument(FileInfo filename, FileInfo template, Hashtable hbookmarks)
        {
            Application wordApp = new Application();
            Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(template.ToString());
            //wordApp.Visible = true;
            try
            {
                foreach (var bookmark in hbookmarks.Keys)
                {

                    if (document.Bookmarks.Exists(bookmark.ToString()))
                    {
                        var ts = new TypeSwitch()
                            .Case((InsertedObject insertedObject) =>
                            {
                                InlineShape shape = document.Bookmarks[bookmark].Range.InlineShapes.AddPicture(FileName: insertedObject.FromFile.FullName);
                                var proportion = shape.Width / shape.Height;

                                shape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
                                shape.Height = insertedObject.Height;
                                shape.Width = shape.Height * proportion;
                            })
                            .Case((string insertedstr) => document.Bookmarks[bookmark].Range.Text = insertedstr)
                            .Case((CreateFunc createFunc) => { createFunc.Invoke(document.Bookmarks[bookmark].Range); })
                            //ase((Func<Range, Table> ff=>{ff( })
                            ;
                        ts.Switch(hbookmarks[bookmark]);
                    }
                }

            document.SaveAs2(filename.ToString());
                
            
            document.Close(WdSaveOptions.wdSaveChanges);
            wordApp.Quit(WdSaveOptions.wdSaveChanges);
            ExportToPDF(filename);
            }
            catch (Exception ex)

            {
                ex.Message.ToString();
            }
            finally
            { }
           
        }

        public void ExportToPDF(FileInfo fileinfo)
        {
            Application wordApp = new Application();
            try
            {
                
            FileInfo newname = new FileInfo(Path.ChangeExtension(fileinfo.FullName, ".pdf"));
            Microsoft.Office.Interop.Word.Document tempDocument = null;
            tempDocument = wordApp.Documents.Open(fileinfo.FullName,
            MsoTriState.msoTrue, MsoTriState.msoTrue,
            MsoTriState.msoFalse);

                tempDocument.ExportAsFixedFormat(
                    newname.FullName,
                    WdExportFormat.wdExportFormatPDF, false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument);
                tempDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
            }
            catch (Exception er)
            {
            }
            finally
            {
                //document.Close(WdSaveOptions.wdDoNotSaveChanges);
                wordApp.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
        }



    }
}
