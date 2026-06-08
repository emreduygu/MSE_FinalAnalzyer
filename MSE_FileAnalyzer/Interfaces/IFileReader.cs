using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Interfaces
{
    public interface IFileReader
    {
        string ReadContent(string filePath);
        string SupportedExtension { get; }
    }
}
