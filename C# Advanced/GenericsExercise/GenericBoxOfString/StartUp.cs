using System;

namespace GenericBoxOfString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split();
            string[] secondInput = Console.ReadLine().Split();
            string[] thirdInput = Console.ReadLine().Split();

            MyTuple<string, string, string> first = new MyTuple<string, string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2], firstInput[3]);
            MyTuple<string, int, bool> second = new MyTuple<string, int, bool>(secondInput[0], int.Parse(secondInput[1]), secondInput[2] == "drunk");
            MyTuple<string, double, string> third = new MyTuple<string, double, string>(thirdInput[0], double.Parse(thirdInput[1]), thirdInput[2]);

            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);

        }
    }
}
