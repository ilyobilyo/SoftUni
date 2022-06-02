using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Stack_and_Queue
{
    class Stack
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;

        public Stack()
        {
            items = new int[initialCapacity];
            count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public void Push(int element)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = element;
            count++;
        }

        public int Pop()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            int rmovedItam = items[count - 1];
            count--;
            return rmovedItam;
        }

        public int Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return items[count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(items[i]);
            }
        }
    }
}
