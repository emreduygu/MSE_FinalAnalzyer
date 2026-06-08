using DocumentFormat.OpenXml.Office2019.Presentation;
using DocumentFormat.OpenXml.Packaging;
using MSE_FileAnalyzer.Interfaces;
using MSE_FileAnalyzer.Readers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Factories
{
    public class FileReaderFactory
    {
        private static readonly List<IFileReader> _readers = new List<IFileReader>() {
            new TxtFileReader(), new DocxFileReader(), new PdfFileReader()
        };
        public static IFileReader GetReader(string extension) { 
            foreach (IFileReader reader in _readers)
            {
                if(reader.SupportedExtension == extension.ToLower())  return reader;

            }

            throw new NotSupportedException($"'{extension}' file type is not supported.");
        }
        
    }
}
