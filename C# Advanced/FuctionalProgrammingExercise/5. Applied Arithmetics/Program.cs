using System;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int[]> add = array =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i]++;
                }

                return array;
            };
            Func<int[], int[]> multiply = array =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] *= 2;
                }

                return array;
            };
            Func<int[], int[]> subtract = array =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i]--;
                }

                return array;
            };
            Action<int[]> print = arr => Console.WriteLine(string.Join(" ", arr));

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    add(inputNumbers);
                }
                else if (command == "multiply")
                {
                    multiply(inputNumbers);
                }
                else if (command == "subtract")
                {
                    subtract(inputNumbers);
                }
                else if (command == "print")
                {
                    print(inputNumbers);
                }
            }
        }
    }
}
