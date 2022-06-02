namespace ExtractBytes
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"D:\SoftUni\lab\Resources\ExtractBytes\Files\example.png";
            string bytesFilePath = @"D:\SoftUni\lab\Resources\ExtractBytes\Files\bytes.txt";
            string outputPath = @"D:\SoftUni\lab\Resources\ExtractBytes\Files\exampleFile.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            using (var reader = new StreamReader(bytesFilePath))
            {
                byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
                List<string> bytesList = new List<string>();
                var sb = new StringBuilder();

                while (!reader.EndOfStream)
                {
                    bytesList.Add(reader.ReadLine());
                }

                foreach (var item in fileBytes)
                {
                    if (bytesList.Contains(item.ToString()))
                    {
                        sb.Append(item.ToString() + " ");
                    }
                }


                byte[] bytesArray = sb.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();
                File.WriteAllBytes(outputPath, bytesArray);

            }


        }
    }
}

