using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Logging
{
    public class Logger
    {
        private readonly string _logFilePath;

        public Logger() { 
        _logFilePath = $"log_{DateTime.Now:yyyyMMdd}.txt";

        }

        public void Log(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] [INFO] {message}";

            File.AppendAllText(_logFilePath, entry + Environment.NewLine);
            Console.WriteLine(entry);
        }
        public void LogError(string message, Exception ex) {
            string entry = $"[{DateTime.Now:HH:mm:ss}] [ERROR] {message}: {ex.Message}";
            File.AppendAllText(_logFilePath, entry + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(entry);
            Console.ResetColor();
        }

    }
}
