using System;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int> GetCurrentNameSum = name =>
            {
                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += name[i];
                }

                return sum;
            };

            Func<string[], int, string> GetFirstNameWithBiggerSum = (arr, n) =>
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    int sum = 0;
                    sum = GetCurrentNameSum(arr[i]);

                    if (sum >= n)
                    {
                        return arr[i];
                    }
                }

                return null;
            };


            Console.WriteLine(GetFirstNameWithBiggerSum(names, n));
        }
    }
}
