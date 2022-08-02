
namespace Test
{
    class Program
    {
        public static void Main()
        {
            List<string> list = new List<string>();

            var task1 = Task.Run(() =>
            {
                for (int i = 1; i <= 15000000; i++)
                {
                    list.Add($"{i}");
                }

            });

            task1.Wait();

            var task2 = Task.Run(() =>
            {
                for (int i = 200; i < 40000000; i += 2)
                {
                    list.Add($"Async => {i}");
                }

                //Console.WriteLine(String.Join(": ", list));
            });

            string v = Console.ReadLine();

            Console.WriteLine(list.Count);
        }
    }
}