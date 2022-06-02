using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (var reader = new StreamReader(@"D:\SoftUni\lab\Resources\03. Word Count\words.txt"))
            {
                string[] words = reader.ReadLine().Split();
                for (int i = 0; i < words.Length; i++)
                {
                    dict.Add(words[i].ToLower(), 0);
                }

                using (var readerText = new StreamReader(@"D:\SoftUni\lab\Resources\03. Word Count\text.txt"))
                {
                    string line = readerText.ReadLine();
                    
                    while (line != null)
                    {
                        string[] array = line.Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int j = 0; j < array.Length; j++)
                        {
                            if (dict.ContainsKey(array[j].ToLower()))
                            {
                                dict[array[j].ToLower()]++;
                            }
                        }

                        line = readerText.ReadLine();
                    }

                    using (var writer = new StreamWriter(@"D:\SoftUni\lab\Resources\03. Word Count\Output.txt"))
                    {
                        foreach (var pair in dict.OrderByDescending(s => s.Value))
                        {
                            writer.WriteLine($"{pair.Key} - {pair.Value}");
                        }
                    }
                }

            }
        }
    }
}
