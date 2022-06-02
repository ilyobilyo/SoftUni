using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queueSongs = new Queue<string>(inputSongs);
            while (queueSongs.Any())
            {
                string command = Console.ReadLine();
                if (command.Substring(0, 4) == "Play")
                {
                    queueSongs.Dequeue();
                }
                else if (command.Substring(0, 3) == "Add")
                {
                    string song = command.Substring(4);
                    if (!queueSongs.Contains(song))
                    {
                        queueSongs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (command.Substring(0, 4) == "Show")
                {
                    Console.WriteLine(string.Join(", ", queueSongs));
                }
            }

            if (!queueSongs.Any())
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
