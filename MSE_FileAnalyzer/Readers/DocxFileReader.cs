using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using MSE_FileAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Readers
{
    public class DocxFileReader : IFileReader
    {
        public string SupportedExtension => ".docx";

        public string ReadContent(string filePath)
        {
            StringBuilder content = new StringBuilder();

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath,false))
            {
                var body = doc.MainDocumentPart.Document.Body;

                foreach (Text text in body.Descendants<Text>()) {
                    content.Append(text.Text + " ");
                        }
                return content.ToString();
            }
        }
    }
}
