using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Stack_and_Queue
{
    class Queue
    {
        private const int initialCapacity = 4;
        private int[] items;
        private int count;
        private const int firstElementIndex = 0;
        public Queue()
        {
            items = new int[initialCapacity];
            count = 0;
        }

        public int Count
        {
            get
            {
                return count;
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

        public void Enqueue(int element)
        {
            if (count == items.Length)
            {
                Resize();
            }

            items[count] = element;
            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            int value = items[0];

            for (int i = 0; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = default;
            count--;
            return value;
        }
        public int Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException();
            }

            return items[firstElementIndex];
        }

        public void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                items[i] = 0;
            }

            count = 0;
        }

        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
