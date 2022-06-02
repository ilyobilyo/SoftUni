using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartible
    {
        public void BrowsingInWeb(string website)
        {
            bool isValid = true;

            for (int i = 0; i < website.Length; i++)
            {
                if (char.IsDigit(website[i]))
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine($"Browsing: {website}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }

        }

        public void CallingOtherPhones(string number)
        {

            bool isValid = true;

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    isValid = false;
                    break;
                }
            }

            if (!isValid)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }

        }
    }
}
