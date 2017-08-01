using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;

namespace BuildingBlocks
{
    public class Tables
    {
        public static void Create()
        {
            var dest = @"c:\temp\Tables.pdf";
            var writer = new PdfWriter(dest);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.LETTER);
            document.SetMargins(20, 20, 20, 20);
            
            var font = PdfFontFactory.CreateFont(FontConstants.HELVETICA);
            var bold = PdfFontFactory.CreateFont(FontConstants.HELVETICA_BOLD);

            var headerColumnTable = new Table(new float[] { 10, 10 });
            var oneColumnTable = new Table(new float[] { 20 });
            var twoColumnTable = new Table(new float[] { 10, 10 });

            headerColumnTable.SetWidthPercent(100);
            oneColumnTable.SetWidthPercent(100);
            twoColumnTable.SetWidthPercent(100);

            headerColumnTable.AddHeaderCell(
                    new Cell().Add(
                            new Paragraph("test1"))
                        .SetFont(font)
                        .SetFontSize(30)
                        .SetTextAlignment(TextAlignment.CENTER))
                .AddHeaderCell(
                    new Cell().Add(
                            new Paragraph("test2"))
                        .SetFont(font)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER));

            document.Add(headerColumnTable);
            
            oneColumnTable.AddCell(new Cell()
                .Add(new Paragraph("test3")
                .SetFont(font)
                .SetFontSize(10)
                .SetTextAlignment(TextAlignment.CENTER))
                .Add(new Paragraph("test4")
                .SetFont(font)
                .SetFontSize(20)
                .SetTextAlignment(TextAlignment.CENTER)));
            
            document.Add(oneColumnTable);

            twoColumnTable.AddCell(
                    new Cell().Add(
                            new Paragraph("test5")
                        .SetFont(font)
                        .SetFontSize(30)
                        .SetTextAlignment(TextAlignment.CENTER)))
                .AddCell(
                    new Cell().Add(
                            new Paragraph("test6")
                        .SetFont(font)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER)));

            document.Add(twoColumnTable);

            document.Add(new Paragraph("this is the text below the table"));

            var bottomTable = new Table(new float[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });

            
            bottomTable
                .AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER))
                .AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER))
                .AddCell(new Cell().Add(new Paragraph("2")))
                .AddCell(new Cell().Add(new Paragraph("8")))
                .AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER))
                .AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER))
                .AddCell(new Cell().Add(new Paragraph("4")))
                .AddCell(new Cell().Add(new Paragraph("8")))
                .AddCell(new Cell().Add(new Paragraph("4")))
                .AddCell(new Cell().Add(new Paragraph("8")))
                .AddCell(new Cell().Add(new Paragraph("3")))
                .AddCell(new Cell().Add(new Paragraph("8")));

            document.Add(bottomTable);
            document.Close();
        }
    }
}
