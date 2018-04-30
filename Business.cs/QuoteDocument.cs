using DataAccess;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IQuoteDocument
    {
        void GenerateQuoteDocument();
    }

    public class QuoteDocument : IQuoteDocument
    {
        private readonly IDataAccess _data;
        private readonly PdfDocument _document;

        private const string path = @"C:\Users\slitz\Documents\PowerlinkQuoteDocuments\";

        public QuoteDocument(IDataAccess data = null, PdfDocument document = null)
        {
            _data = data ?? new DataAccess.DataAccess();
            _document = document ?? new PdfDocument();
        }

        public void GenerateQuoteDocument()
        {
            PdfPage page = _document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            string filename = path + "HelloWorld.pdf";

            gfx.DrawString("Hello, World!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            
            _document.Info.Title = "Created with PDFsharp";
            _document.Save(filename);

            Process.Start(filename);
        }
    }
}
