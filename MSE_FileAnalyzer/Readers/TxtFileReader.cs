using MSE_FileAnalyzer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Readers
{
    public class TxtFileReader : IFileReader
    {
        public string SupportedExtension => ".txt";

        public string ReadContent(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }
}
