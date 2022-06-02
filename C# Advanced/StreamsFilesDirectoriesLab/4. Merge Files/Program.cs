using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var readerFileOne = new StreamReader(@"D:\SoftUni\lab\Resources\04. Merge Files\FileOne.txt"))
            {
                string lineOne = readerFileOne.ReadLine();

                using (var readerFileTwo = new StreamReader(@"D:\SoftUni\lab\Resources\04. Merge Files\FileTwo.txt"))
                {
                    string lineTwo = readerFileTwo.ReadLine();

                    using (var writer = new StreamWriter(@"D:\SoftUni\lab\Resources\04. Merge Files\Output.txt"))
                    {
                        while (lineOne != null || lineTwo != null)
                        {

                            if (lineOne != null && lineTwo == null)
                            {
                                writer.WriteLine(lineOne);
                                lineOne = readerFileOne.ReadLine();
                            }
                            else if (lineOne == null && lineTwo != null)
                            {
                                writer.WriteLine(lineTwo);
                                lineTwo = readerFileTwo.ReadLine();
                            }
                            else
                            {
                                writer.WriteLine(lineOne);
                                writer.WriteLine(lineTwo);
                                lineOne = readerFileOne.ReadLine();
                                lineTwo = readerFileTwo.ReadLine();

                            }

                        }
                    }
                }
            }
        }
    }
}
