using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList() { "ils", "op", "pepd" };
            Console.WriteLine(list.RandomString());
        }
    }
}
