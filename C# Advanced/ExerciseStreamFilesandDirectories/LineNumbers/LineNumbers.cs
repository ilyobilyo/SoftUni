namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] allLines = File.ReadAllLines(inputFilePath);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < allLines.Length; i++)
            {
                int countLetters = allLines[i].Count(char.IsLetter);
                int countPunctuacion = allLines[i].Count(char.IsPunctuation);

                sb.AppendLine($"Line {i + 1}: {allLines[i]} ({countLetters})({countPunctuacion})");
            }

            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
