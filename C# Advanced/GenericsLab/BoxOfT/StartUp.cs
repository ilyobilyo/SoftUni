using System;

namespace BoxOfT
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> nums = new Box<int>();
            nums.Add(1);
            nums.Add(100);
            nums.Add(2);
            nums.Add(200);
            Console.WriteLine(nums.Remove());
            nums.Add(4);
            Console.WriteLine(nums.Remove());

            Box<string> strings = new Box<string>();

            strings.Add("ad");
            strings.Add("adadad");
            strings.Add("adggga");
            strings.Add("last");
            Console.WriteLine(strings.Remove());
        }
    }
}
