namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using var reader = new StringReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    ReplaceSymbols(line);

                    line = string.Join(" ", line.Split().Reverse());

                    sb.AppendLine(line);
                }

                counter++;
            }

            return sb.ToString();
        }


        private static string ReplaceSymbols(string line)
        {
            char[] replacedChars = new char[] { '-', ',', '.', '!', '?' };
            foreach (var symbol in replacedChars)
            {
                line = line.Replace(symbol, '@');
            }

            return line;
        }
    }

}
