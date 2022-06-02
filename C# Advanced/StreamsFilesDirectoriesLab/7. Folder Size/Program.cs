namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\FolderSize\Files\TestFolder";
            string outputPath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\FolderSize\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            double sum = 0;
            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (var fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            sum = sum / 1024;
            File.WriteAllText(outputFilePath, sum.ToString());
        }
    }
}
