using common.Office;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using Utility;

namespace common
{
    public class Word_Operator : IOutDocument<FileInfo>
    {
        public Application wordApp = new Application();

        public delegate Table CreateFunc(Range range, string duType = null);

        public void CreateBookmarkedDocument(FileInfo filename, FileInfo template, Hashtable hbookmarks, IEnumerable<WdSaveFormat> wdSaveFormats = null)
        {
            if (wdSaveFormats == null)
            {
                wdSaveFormats = new List<WdSaveFormat>();
                ((List<WdSaveFormat>)wdSaveFormats).Add(WdSaveFormat.wdFormatDocument);
            }
            //Application wordApp = new Application();
            Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(template.FullName);
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

                                shape.LockAspectRatio = MsoTriState.msoTrue;
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
                foreach (var format in wdSaveFormats)
                    document.SaveAs2(Path.ChangeExtension(filename.FullName, null), format);
                document.PrintOut();

                document.Close(WdSaveOptions.wdDoNotSaveChanges);
                //ExportToPDF(filename);
            }
            catch (Exception ex)

            {
                ex.Message.ToString();
            }
            finally
            {
                //wordApp.Quit(WdSaveOptions.wdSaveChanges);
            }

        }

        public void ExportToPDF(FileInfo fileinfo)
        {
            //Application wordApp = new Application();
            Microsoft.Office.Interop.Word.Document tempDocument = null;
            try
            {

                FileInfo newname = new FileInfo(Path.ChangeExtension(fileinfo.FullName, ".pdf"));

                tempDocument = wordApp.Documents.Open(fileinfo.FullName,
                MsoTriState.msoTrue, MsoTriState.msoTrue,
                MsoTriState.msoFalse);

                tempDocument.ExportAsFixedFormat(
                    newname.FullName,
                    WdExportFormat.wdExportFormatPDF, false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument);
                //tempDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
            }
            catch (Exception er)
            {
#if DEBUG
                Logger.Log.Debug(er.Message);
#else
                Logger.Log.Error(er.Message);
#endif
            }
            finally
            {
                if (tempDocument != null)
                    tempDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
                //wordApp.Quit(WdSaveOptions.wdDoNotSaveChanges);
            }
        }

        public void Create(FileInfo document)
        {
            throw new NotImplementedException();
        }

        public void Print(FileInfo document, short copies = 1)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerable<FileInfo> document)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<FileInfo> document, short copies = 1)
        {
            throw new NotImplementedException();
        }

        public void Print(FileInfo document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public void Print(IEnumerable<FileInfo> document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }
    }
}
