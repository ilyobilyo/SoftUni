using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IPhone stationaryPhone = new StationaryPhone();
            ISmartible smartPhone = new Smartphone();

            foreach (var number in numbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.CallingOtherPhones(number);
                }
                else if (number.Length == 10)
                {
                    smartPhone.CallingOtherPhones(number);
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            foreach (var site in sites)
            {
                smartPhone.BrowsingInWeb(site);
            }
        }
    }
}
