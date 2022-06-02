using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minFunc = n =>
            {
                int min = int.MaxValue;
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] < min)
                    {
                        min = input[i];
                    }
                }

                return min;
            };

            Console.WriteLine(minFunc(input));
        }

    }
}
