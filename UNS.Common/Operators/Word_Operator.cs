using UNS.Common.Interfaces;
using UNS.Common.Office;
using UNS.Common.Operators;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using Utility;
using Logger;

namespace UNS.Common
{
    public class Word_Operator<T> : IOutDocument<T>
    {
        public static Application wordApp = new Application();
        public delegate Table CreateFunc(Range range, string duType = null);
        public Document CreateBookmarkedDocument(FileInfo template, Hashtable hbookmarks)
        {
            Document document = wordApp.Documents.Add(template.FullName);
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
                            .Case((CreateFunc createFunc) => { createFunc.Invoke(document.Bookmarks[bookmark].Range); });
                        ts.Switch(hbookmarks[bookmark]);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex.Message);
            }
            return document;
            }
        public IEnumerable<FileInfo> CreateBookmarkedDocument(string fileBaseName, FileInfo template, Hashtable hbookmarks, IEnumerable<WdSaveFormat> wdSaveFormats = null)
        {
            if (wdSaveFormats == null)
            {
                wdSaveFormats = new List<WdSaveFormat>()
                { WdSaveFormat.wdFormatDocument };
            }
            Document document = CreateBookmarkedDocument(template,hbookmarks);
            var result = new List<FileInfo>();
            try
            { 
                foreach (var format in wdSaveFormats)
                {
                    document.SaveAs2(fileBaseName, format);
                    result.Add(new FileInfo(fileBaseName));
                }
                Logger.Logger.Info(fileBaseName);
            }
            catch (Exception ex)
            {
                Logger.Logger.Error(ex.Message);
            }
            finally
            {
                document.Close(WdSaveOptions.wdDoNotSaveChanges);
            }
            return result;
        }

        public virtual void ExportToPDF(FileInfo fileinfo)
        {
            Document tempDocument = null;
            try
            {
                FileInfo newname = new FileInfo(Path.ChangeExtension(fileinfo.FullName, ".pdf"));
                tempDocument = wordApp.Documents.Open(fileinfo.FullName,MsoTriState.msoTrue, MsoTriState.msoTrue,MsoTriState.msoFalse);
                tempDocument.ExportAsFixedFormat(
                    newname.FullName,
                    WdExportFormat.wdExportFormatPDF, false, WdExportOptimizeFor.wdExportOptimizeForPrint, WdExportRange.wdExportAllDocument);
            }
            catch (Exception er)
            {
#if DEBUG
                Logger.Logger.Debug(er.Message);
#else
                Logger.Logger.Error(er.Message);
#endif
            }
            finally
            {
                if (tempDocument != null)
                    tempDocument.Close(WdSaveOptions.wdDoNotSaveChanges);
            }
        }

        public virtual FileInfo Create(T document)
        {
            throw new NotImplementedException();
        }
        public virtual IEnumerable<FileInfo> Create(IEnumerable<FileInfo> document)
        {
            throw new NotImplementedException();
        }

        public virtual void Print(FileInfo document, PrinterSettings printerSettings)
        {
            wordApp.Documents.Open(document.FullName);
            wordApp.PrintOut();
        }

        public virtual void Print(IEnumerable<FileInfo> documents, PrinterSettings printerSettings)
        {
            foreach (var document in documents)
            { Print(document, printerSettings); }
        }


        public virtual void Print(T document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<FileInfo> Create(IEnumerable<T> document)
        {
            throw new NotImplementedException();
        }

        public virtual void Print(IEnumerable<T> document, PrinterSettings printerSettings)
        {
            throw new NotImplementedException();
        }
    }
}
