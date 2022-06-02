using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(2, "ils");
            int[] nums = ArrayCreator.Create(3, 5);
        }
    }
}
