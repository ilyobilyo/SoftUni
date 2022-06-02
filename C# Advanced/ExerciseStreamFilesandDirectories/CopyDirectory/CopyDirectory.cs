namespace CopyDirectory
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            string[] files = Directory.GetFiles(inputPath, "*");

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }
            else
            {
                Directory.CreateDirectory(outputPath);
            }

            foreach (var file in files)
            {
                string fileName = outputPath + "\\" + Path.GetFullPath(file);
                File.Copy(file, outputPath);
            }
        }
    }
}
