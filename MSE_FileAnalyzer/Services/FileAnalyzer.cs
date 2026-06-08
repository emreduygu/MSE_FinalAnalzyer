
using System;
using System.IO;
using MSE_FileAnalyzer.Factories;
using MSE_FileAnalyzer.Logging;

namespace MSE_FileAnalyzer.Services
{
    public class FileAnalyzerService
    {
        private readonly Logger _logger;
        private readonly TextAnalyzer _analyzer;

        public FileAnalyzerService(Logger logger)
        {
            _logger = logger;
            _analyzer = new TextAnalyzer();
        }

        public void Analyze(string filePath)
        {
            try
            {
                _logger.Log($"File selected: {filePath}");

                
                string extension = Path.GetExtension(filePath);
                var reader = FileReaderFactory.GetReader(extension);

                _logger.Log("Readin file content...");
                string content = reader.ReadContent(filePath);

                _logger.Log("Analyzing content...");
                int uniqueWords = _analyzer.CountingUniqueWords(content);
                var frequencies = _analyzer.GetWordFrequencies(content);
                var punctuations = _analyzer.GetPunctuationCounts(content);

                Console.WriteLine("\n========== ANALYSIS RESULT ==========");
                Console.WriteLine($"Total unique words: {uniqueWords}");
                Console.WriteLine("\n--- Word Frequencies ---");
                int count = 0;
                foreach (var kv in frequencies)
                {
                    if (count++ >= frequencies.Count) break;
                    Console.WriteLine($" {kv.Key,-20} {kv.Value} times");

                }
                Console.WriteLine("\n--- Punctuation Counts ---");
                foreach (var kv in punctuations)
                {
                    Console.WriteLine($" '{kv.Key}'  :  '{kv.Value}'");

                    
                }
                Console.WriteLine("=======================================\n");
                _logger.Log("Analysis completed successfully.");

            }

            catch (NotSupportedException ex) { _logger.LogError("Unsupported file type", ex); }
            catch (FileNotFoundException ex) { _logger.LogError("File not found", ex); }
            catch (Exception ex) { _logger.LogError("Unexpected error during analysis", ex); }


        }
    }
}
