using System;
using System.Text;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = "@#+[A-Z][a-zA-Z0-9]{4,}[A-Z]@#+";

            var regex = new Regex(pattern);

            int countBarcodes = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < countBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                if (!regex.IsMatch(barcode))
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                for (int j = 0; j < barcode.Length; j++)
                {
                    if (char.IsDigit(barcode[j]))
                    {
                        sb.Append(barcode[j]);
                    }
                }

                if (sb.Length > 0)
                {
                    Console.WriteLine($"Product group: {sb}");
                    sb.Clear();
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
            }
        }
    }
}
