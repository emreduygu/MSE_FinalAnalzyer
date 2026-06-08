using System;
using System.Windows.Forms;
using MSE_FileAnalyzer.Logging;
using MSE_FileAnalyzer.Services;

namespace MSE_FileAnalyzer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Logger logger =new Logger();
            logger.Log("Application started");

            Console.WriteLine("=== MSI FİLE ANALYZER ===");
            Console.WriteLine("openning file section dialog...\n");

            using (OpenFileDialog dialog = new OpenFileDialog()) {
                dialog.Title = "Select a file to analyze";
                dialog.Filter = "Supported Files|*.txt;*.docx,*.pdf|Text Files|*.txt|Word Files|*.docx|Pdf Files|*.pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FileAnalyzerService service = new FileAnalyzerService(logger);
                    service.Analyze(dialog.FileName);

                }
                else {
                    Console.WriteLine("NO FILE IS SELECTED");
                    logger.Log("User cancelled file selection");

                }
            
            }
            Console.WriteLine("press any key to exit");
            Console.ReadKey();
        }
    }
}