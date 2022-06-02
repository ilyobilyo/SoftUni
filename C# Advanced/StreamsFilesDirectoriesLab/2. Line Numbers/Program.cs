using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\SoftUni\lab\Resources\02. Line Numbers\Input.txt"))
            {
                string line = reader.ReadLine();
                int count = 1;

                using (var writer = new StreamWriter(@"D:\SoftUni\lab\Resources\02. Line Numbers\Output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{count}. {line}");
                        line = reader.ReadLine();
                        count++;
                    }
                }
            }

        }
    }
}
