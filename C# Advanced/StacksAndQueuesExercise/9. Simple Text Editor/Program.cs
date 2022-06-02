using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            Stack<string> undo = new Stack<string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < operations; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "1")
                {
                    undo.Push(sb.ToString());
                    sb.Append(command[1]);
                }
                else if (command[0] == "2")
                {
                    undo.Push(sb.ToString());
                    int count = int.Parse(command[1]);
                    sb.Remove(sb.Length - count, count);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(sb[index - 1]);
                }
                else if (command[0] == "4")
                {
                    sb.Clear();
                    sb.Append(undo.Pop());
                }
            }
        }
    }
}
