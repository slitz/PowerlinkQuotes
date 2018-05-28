using DataAccess;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
            string filename = path + "project_quote.pdf";
            PdfPage page = _document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Logo
            string fileDirectory =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string filePath = fileDirectory.Substring(6);
            string imageLoc = filePath + @"\Images\powerlink_logo3.jpg";
            // XRect logoRect = new XRect((page.Width / 2) - (250 / 2), 50, 250, 41);
            XRect logoRect = new XRect(43, 50, 225, 38);
            DrawImage(gfx, imageLoc, logoRect);

            // Contact
            const string contactInfo =
                "150 Elizabeth Steet\n" +
                "Rochester, MI 48307\n" +
                "586.337.7607";
            XFont contactfont = new XFont("Calibri", 10, XFontStyle.Regular);
            XTextFormatter contactTf = new XTextFormatter(gfx);
            // XRect rect = new XRect((page.Width / 2) - (250 / 2), 125, 250, 220);
            XRect contactRect = new XRect((page.Width / 2), 50, 250, 100);
            contactTf.Alignment = XParagraphAlignment.Right;
            contactTf.DrawString(contactInfo, contactfont, XBrushes.Gray, contactRect, XStringFormats.TopLeft);

            // Heading
            XFont font = new XFont("Calibri", 14, XFontStyle.Regular);
            XTextFormatter tf = new XTextFormatter(gfx);
            XRect headingRect = new XRect((page.Width / 2) - (250 / 2), 125, 250, 220);
            //XRect headingRect = new XRect(50, 125, 225, 38);
            tf.Alignment = XParagraphAlignment.Center;
            tf.DrawString("PROJECT QUOTE", font, XBrushes.Gray, headingRect, XStringFormats.TopLeft);

            _document.Info.Title = "Powerlink Systems Project Quote";
            _document.Save(filename);

            Process.Start(filename);
        }

        private void DrawImage(XGraphics gfx, string jpegSamplePath, XRect rect)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, rect);
        }
    }
}
