using Microsoft.Office.Interop.Word;
using UNSData.Entities;

namespace common
{
    public sealed class DUTypesTable_Creator
    {

        public Table Create(Range range, IntegraDUExcelLayout integraDUExcelLayout)
        { return Create(range, integraDUExcelLayout.DUType); }
        public static Table Create(Range range, string duType = null)
        {
            Table result = range.Tables.Add(range, 3, 7);
            result.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderRight].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderTop].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderBottom].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderHorizontal].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderHorizontal].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderVertical].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderVertical].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            result.Borders[WdBorderType.wdBorderLeft].LineWidth = WdLineWidth.wdLineWidth050pt;
            result.TopPadding = result.Application.CentimetersToPoints(0);
            result.BottomPadding = result.Application.CentimetersToPoints(0);
            result.LeftPadding = result.Application.CentimetersToPoints(0);
            result.RightPadding = result.Application.CentimetersToPoints(0);
            result.Spacing = 0;
            result.AllowPageBreaks = true;
            result.AllowAutoFit = true;
            result.Columns[1].Width = result.Application.CentimetersToPoints((float)4.5);
            result.Columns[2].Width = result.Application.CentimetersToPoints(3);
            result.Columns[3].Width = result.Application.CentimetersToPoints(3);
            result.Columns[4].Width = result.Application.CentimetersToPoints(3);
            result.Columns[5].Width = result.Application.CentimetersToPoints(1);
            result.Columns[6].Width = result.Application.CentimetersToPoints(1);
            result.Columns[7].Width = result.Application.CentimetersToPoints(1);

            result.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            result.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            result.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            result.Range.Font.Name = "Times New Roman";
            result.Range.Font.Size = 8;
            result.Range.Font.Bold = 0;

            result.Rows[1].Cells[1].Range.Text = "Характеристики";
            result.Rows[2].Cells[1].Range.Text = "Типоисполнение";
            result.Rows[1].Cells[2].Range.Text = "Назначение";
            result.Rows[1].Cells[3].Range.Text = "Количество светодиодов";
            result.Rows[1].Cells[4].Range.Text = "Мощность, Вт";
            result.Rows[2].Cells[5].Range.Text = "L";
            result.Rows[2].Cells[6].Range.Text = "B";
            result.Rows[2].Cells[7].Range.Text = "H";

            switch (duType)
            {
                case "ДУ-М-Д":
                    result.Cell(3, 1).Range.Text = "ДУ-магистральный; ДУ-К-Д";
                    result.Cell(3, 2).Range.Text = "Номер дома";
                    result.Cell(3, 2).Range.Text = "20";
                    result.Cell(3, 2).Range.Text = "6,5";
                    result.Cell(3, 2).Range.Text = "475";
                    result.Cell(3, 2).Range.Text = "475";
                    result.Cell(3, 2).Range.Text = "75";
                    break;
                case "ДУ-М-УД":
                    result.Rows.Add(result.Rows[3]);
                    result.Cell(3, 1).Range.Text = "ДУ-магистральный; ДУ-М-У";
                    result.Cell(3, 2).Range.Text = "Название улицы";
                    result.Cell(3, 3).Range.Text = "100";
                    result.Cell(3, 4).Range.Text = "48";
                    result.Cell(3, 5).Range.Text = "1900";
                    result.Cell(3, 6).Range.Text = "475";
                    result.Cell(3, 7).Range.Text = "75";
                    result.Cell(4, 1).Range.Text = "ДУ-магистральный; ДУ-М-Д";

                    result.Cell(4, 2).Range.Text = "Номер дома";
                    result.Cell(4, 3).Range.Text = "20";
                    result.Cell(4, 4).Range.Text = "6,5";
                    result.Cell(4, 5).Range.Text = "475";
                    result.Cell(4, 6).Range.Text = "475";
                    result.Cell(4, 7).Range.Text = "75";
                    break;
                case "ДУ-К-УД":
                    result.Rows.Add(result.Rows[3]);
                    result.Cell(3, 1).Range.Text = "ДУ-квартальный; ДУ-К-У";
                    result.Cell(3, 2).Range.Text = "Название улицы";
                    result.Cell(3, 3).Range.Text = "42";
                    result.Cell(3, 4).Range.Text = "21";
                    result.Cell(3, 5).Range.Text = "1300";
                    result.Cell(3, 6).Range.Text = "325";
                    result.Cell(3, 7).Range.Text = "75";

                    result.Cell(4, 1).Range.Text = "ДУ-квартальный; ДУ-К-Д";
                    result.Cell(4, 2).Range.Text = "Номер дома";
                    result.Cell(4, 3).Range.Text = "9";
                    result.Cell(4, 4).Range.Text = "4,5";
                    result.Cell(4, 5).Range.Text = "325";
                    result.Cell(4, 6).Range.Text = "325";
                    result.Cell(4, 7).Range.Text = "75";
                    break;
                case "ДУ-К-Д":
                    result.Cell(4, 1).Range.Text = "ДУ-квартальный; ДУ-К-Д";
                    result.Cell(4, 2).Range.Text = "Номер дома";
                    result.Cell(4, 3).Range.Text = "9";
                    result.Cell(4, 4).Range.Text = "4,5";
                    result.Cell(4, 5).Range.Text = "325";
                    result.Cell(4, 6).Range.Text = "325";
                    result.Cell(4, 7).Range.Text = "75";
                    break;
                case "ДУ-К-С":
                    result.Rows.Add(result.Rows[3]);
                    result.Cell(3, 1).Range.Text = "ДУ-квартальный; ДУ-К-С";
                    result.Cell(3, 2).Range.Text = "Название улицы, Номер дома";
                    result.Cell(3, 3).Range.Text = "42";
                    result.Cell(3, 4).Range.Text = "21";
                    result.Cell(3, 5).Range.Text = "1300";
                    result.Cell(3, 6).Range.Text = "325";
                    result.Cell(3, 7).Range.Text = "75";
                    break;
            }
            result.Cell(1, 2).Merge(result.Cell(2, 2));
            result.Cell(1, 3).Merge(result.Cell(2, 3));
            result.Cell(1, 4).Merge(result.Cell(2, 4));
            result.Cell(1, 5).Merge(result.Cell(1, 6));
            result.Cell(1, 5).Merge(result.Cell(1, 6));
            result.Cell(1, 5).Range.Text = "Габариты, мм";

            return result;

        }

    }
}
