namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\SplitMergeBinaryFile\Files\example.png";
            string joinedFilePath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\SplitMergeBinaryFile\Files\example-joined.png";
            string partOnePath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\SplitMergeBinaryFile\Files\part-1.bin";
            string partTwoPath = @"D:\SoftUni\lab\Resources\Skeleton-Lab\Skeleton\SplitMergeBinaryFile\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {

            byte[] bytesBinary = File.ReadAllBytes(sourceFilePath);
            if (bytesBinary.Length % 2 != 0)
            {
                byte[] bytesFirst = new byte[bytesBinary.Length / 2 + 1];
                byte[] bytesSecond = new byte[bytesBinary.Length / 2];

                for (int i = 0; i < bytesFirst.Length; i++)
                {
                    bytesFirst[i] = bytesBinary[i];
                }

                int count = 0;
                for (int i = bytesBinary.Length / 2 + 1; i < bytesBinary.Length; i++)
                {
                    bytesSecond[count] = bytesBinary[i];
                    count++;
                }

                File.WriteAllBytes(partOneFilePath, bytesFirst);
                File.WriteAllBytes(partTwoFilePath, bytesSecond);


            }
            else
            {
                byte[] bytesFirst = new byte[bytesBinary.Length / 2];
                byte[] bytesSecond = new byte[bytesBinary.Length / 2];

                for (int i = 0; i < bytesFirst.Length; i++)
                {
                    bytesFirst[i] = bytesBinary[i];
                }

                int count = 0;
                for (int i = bytesBinary.Length / 2; i < bytesBinary.Length; i++)
                {
                    bytesSecond[count] = bytesBinary[i];
                    count++;
                }

                File.WriteAllBytes(partOneFilePath, bytesFirst);
                File.WriteAllBytes(partTwoFilePath, bytesSecond);
            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            byte[] bytesBinaryFirst = File.ReadAllBytes(partOneFilePath);
            byte[] bytesBinarySecond = File.ReadAllBytes(partTwoFilePath);
            byte[] mergingFiles = new byte[bytesBinaryFirst.Length + bytesBinarySecond.Length];

            for (int i = 0; i < bytesBinaryFirst.Length; i++)
            {
                mergingFiles[i] = bytesBinaryFirst[i];
            }


            int counter = 0;
            for (int i = bytesBinaryFirst.Length; i < mergingFiles.Length; i++)
            {
                mergingFiles[i] = bytesBinarySecond[counter];
                counter++;
            }

            File.WriteAllBytes(joinedFilePath, mergingFiles);

        }
    }
}