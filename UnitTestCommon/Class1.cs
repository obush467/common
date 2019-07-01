using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestCommon
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void CreatePassport111()
        {
            string fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.TTF");
            BaseFont fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fgFont = new iTextSharp.text.Font(fgBaseFont, 10, iTextSharp.text.Font.NORMAL, BaseColor.GREEN);

            Phrase p = new Phrase(@"Русский текст.", fgFont);
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("C:\\Макеты\\Document.pdf", FileMode.Create));
            doc.Open();
            //iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("C:\\Макеты\\ДУ-К-Д\\1 корпус 1 строение 1.png");
            //jpg.Alignment = Element.ALIGN_CENTER;
            //doc.Add(jpg);
            PdfPTable table = new PdfPTable(3);
            PdfPCell cell = new PdfPCell(new Phrase("Simple table",
              new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 16,
              iTextSharp.text.Font.NORMAL, new BaseColor(Color.Orange))));
            cell.BackgroundColor = new BaseColor(Color.Wheat);
            cell.Padding = 5;
            cell.Colspan = 3;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            table.AddCell("Col 1 Row 1");
            table.AddCell("Col 2 Row 1");
            table.AddCell("Col 3 Row 1");
            table.AddCell("Col 1 Row 2");
            table.AddCell("Col 2 Row 2");
            table.AddCell("Col 3 Row 2");
            //jpg = iTextSharp.text.Image.GetInstance("C:\\Макеты\\ДУ-К-Д\\1 корпус 1 строение 1.png");
            //cell = new PdfPCell(jpg);
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Col 2 Row 3"));
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            table.AddCell(cell);
            //jpg = iTextSharp.text.Image.GetInstance("C:\\Макеты\\ДУ-К-Д\\1 корпус 1 строение 1.png");
            //cell = new PdfPCell(jpg);
            cell.Padding = 5;
            cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            table.AddCell(cell);
            doc.Add(table);
            doc.Add(new Paragraph("Технический паспорт домового указателя", fgFont));
            doc.Add(new Paragraph("Уникальный номер: 03060ДУ800039.", fgFont));
            doc.Add(new Paragraph(p));
            doc.Add(new Paragraph("ОПИСАНИЕ И ОСНОВНЫЕ ХАРАКТЕРИСТИКИ", fgFont));
            var rr = new iTextSharp.text.List(true);
            rr.Add(new ListItem("1.1. Домовый указатель с светодиодной подсветкой предназначен для работы в сетях переменного тока напряжением 220В частота 50Гц", fgFont));
            rr.Add(new ListItem("1.2. Домовый указатель применяется для визуальной навигации в городских условиях, в пределах   квартальной застройки и магистральных автодорог.", fgFont));
            rr.Add(new Paragraph("1.3. Домовыfswfsdfswfewrewrwerwerй указатель со светодиодной подсветкой изготавливается ", fgFont));
            doc.Add(rr);            doc.Close();
        }
    }
}