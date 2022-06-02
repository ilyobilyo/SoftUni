using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locks = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Stack<int> stackBullet = new Stack<int>(bullets);
            Queue<int> queueLocks = new Queue<int>(locks);

            int reloading = 0;
            int countBullets = 0;

            while (stackBullet.Any() && queueLocks.Any())
            {
                int currBullet = stackBullet.Pop();
                countBullets++;
                int currentLock = queueLocks.Peek();

                if (currBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    queueLocks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                reloading++;
                if (reloading == gunBarrelSize && stackBullet.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    reloading = 0;
                }

            }

            if (!queueLocks.Any())
            {
                int bulletCost = countBullets * bulletPrice;
                int earnedMoney = intelligence - bulletCost;
                Console.WriteLine($"{stackBullet.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
        }
    }
}
