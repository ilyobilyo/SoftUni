namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();

            foreach (var filepath in files)
            {
                string fileName = Path.GetFileName(filepath);
                string exention = Path.GetExtension(filepath);
                double size = new FileInfo(filepath).Length / 1024.0;

                if (!dict.ContainsKey(exention))
                {
                    dict.Add(exention, new Dictionary<string, double>());
                }

                dict[exention].Add(fileName, size);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var extention in dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(extention.Key);
                foreach (var file in extention.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{file.Key} - {file.Value:f3}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\report.txt";
        }

    }
}
