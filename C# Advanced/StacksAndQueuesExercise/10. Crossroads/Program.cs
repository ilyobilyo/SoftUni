using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            bool isCrashed = false;
            int passedCars = 0;
            int remainingSecond = 0;
            Queue<string> carsQueue = new Queue<string>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                if (command != "green")
                {
                    carsQueue.Enqueue(command);
                }
                else
                {
                    if (carsQueue.Any())
                    {
                        int currCarLength = carsQueue.Peek().Length;
                        remainingSecond = greenLightSeconds;
                        while (remainingSecond > 0 && carsQueue.Any())
                        {
                            //Ako vleze tuk zaduljitelno kolata izchezva ot opashkata !!
                            string carName = carsQueue.Dequeue();

                            //Ako moje da mine na zeleno
                            if (remainingSecond - carName.Length >= 0)
                            {
                                //Promqna na ostavashtoto vreme zashtoto e minala na zeleno
                                remainingSecond -= carName.Length;
                                passedCars++;
                                continue;
                            }
                            //Ako moje da mine na julto(Free Window) 
                            else if (remainingSecond + freeWindowSeconds - carName.Length >= 0)
                            {
                                //Nikoi osven kolata ne moje da premine poveche prez krastovishteto za tova remeiningSeconds stava 0
                                remainingSecond = 0;
                                passedCars++;
                                continue;
                            }
                            //Ako ne preminava a e vlqzla v krastovishteto stava PTP
                            else
                            {
                                char crashChar = carName[Math.Abs(remainingSecond + freeWindowSeconds)];
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carName} was hit at {crashChar}.");
                                isCrashed = true;
                                break;
                            }

                        }

                    }
                }
            }

            if (!isCrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
