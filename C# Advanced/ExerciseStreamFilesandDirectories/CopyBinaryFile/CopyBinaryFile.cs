namespace CopyBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using var fileStreamReader = new FileStream(inputFilePath, FileMode.Open);
            using var fileStreamWriter = new FileStream(outputFilePath, FileMode.Create);

            byte[] bytes = new byte[256];

            while (true)
            {
                int currBytes = fileStreamReader.Read(bytes, 0, bytes.Length);

                if (currBytes == 0)
                {
                    break;
                }

                fileStreamWriter.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
