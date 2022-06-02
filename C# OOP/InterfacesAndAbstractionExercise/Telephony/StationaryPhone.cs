using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
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
                Console.WriteLine($"Dialing... {number}");
            }

        }
    }
}
