using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MSE_FileAnalyzer.Services
{
    public class TextAnalyzer
    {
        private static readonly HashSet<string> StopWords = new HashSet<string>() {
         "ve", "veya", "ile", "de", "da", "ki", "bir", "bu", "şu", "o",
            "the", "and", "or", "a", "an", "in", "on", "at", "to", "for",
            "is", "are", "was", "were", "be", "been"
    };
        private static readonly char[] Punctuations = { '.', ',', '!', '?', ';', ':', '-', '(', ')', '"', '\'' };

        public int CountingUniqueWords(string content)
        {
            return GetWordFrequencies(content).Count();
        }

        public Dictionary<string, int> GetWordFrequencies(string content)
        {

            string cleaned = Regex.Replace(content, @"[^a-zA-ZğüşıöçĞÜŞİÖÇ\s]", " ");

            var words = cleaned.Split(new char[] { ' ', '\n', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(w => w.ToLower()).Where(w => w.Length > 1).Where(w => !StopWords.Contains(w)).Where(w => !Regex.IsMatch(w, @"^\d+$"));

            var frequencies = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                    frequencies[word]++;
                else frequencies[word] = 1;
            }

            return frequencies.OrderByDescending(kv => kv.Value).ToDictionary(kv => kv.Key, kv => kv.Value);
        }
        public Dictionary<char, int> GetPunctuationCounts(string content)
        {
            var counts = new Dictionary<char, int>();

            foreach (char c in content)
            {
                if (Array.IndexOf(Punctuations, c) >= 0)
                {
                    if (counts.ContainsKey(c))
                        counts[c]++;
                    else counts[c] = 1;
                }
            }
            return counts;
        }
    }
}