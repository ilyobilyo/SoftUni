using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\SoftUni\lab\Resources\01. Odd Lines\Input.txt"))
            {
                int count = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (count % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    count++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
