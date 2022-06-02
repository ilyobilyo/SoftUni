using System;

namespace Implementing_Stack_and_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomList list = new CustomList();
            //list.Add(3);
            //list.Add(8);
            //list.Add(4);
            //Console.WriteLine(list.Contains(4));
            //Console.WriteLine(list.Contains(100));

            //list.Swap(1, 2);
            //list.Swap(1, 3);

            //list.Add(6);
            //list.Add(15);
            //list.Add(9);
            //list.Insert(1, 100);
            //list.RemoveAt(3);
            //Console.WriteLine(list.Count);

            Stack stack = new Stack();
            stack.Push(2);
            stack.Push(4);
            stack.Push(7);
            stack.Push(200);

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            stack.ForEach(x => Console.WriteLine(x));

            Queue qu = new Queue();
            qu.Enqueue(3);
            qu.Enqueue(50);
            qu.Enqueue(2000);
            qu.Enqueue(68);
            qu.Enqueue(600);

            qu.Clear();
            Console.WriteLine(qu.Dequeue());
        }
    }
}
