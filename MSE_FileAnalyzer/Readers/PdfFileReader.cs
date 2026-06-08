using DocumentFormat.OpenXml.Spreadsheet;
using MSE_FileAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;



namespace MSE_FileAnalyzer.Readers
{
    public class PdfFileReader : IFileReader
    {
        public string SupportedExtension => ".pdf";



        public string ReadContent(string filePath)
        {

            var sb = new StringBuilder();

            using (var document = PdfDocument.Open(filePath))
            {
                foreach (var page in document.GetPages())
                {
                    sb.AppendLine(page.Text);
                }
                return sb.ToString();
            }
        }

    }
}
