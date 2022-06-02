using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_Stack_and_Queue
{
    class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
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

        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        private bool IsIndexOutOfRange(int index)
        {
            return index >= Count || index < 0;
            
        }

        public int RemoveAt(int index)
        {
            if (IsIndexOutOfRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int value = items[index];
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
            if (Count <= items.Length / 2)
            {
                Shrink();
            }
            return value;
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

        public void Insert(int index, int item)
        {
            if (IsIndexOutOfRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            for (int i = Count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = item;
            Count++;
        }

        public bool Contains(int element)
        {
            bool isContains = false;

            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    isContains = true;
                }
            }

            return isContains;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (IsIndexOutOfRange(firstIndex) || IsIndexOutOfRange(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            int firstValue = items[firstIndex];
            int secondValue = items[secondIndex];

            items[firstIndex] = secondValue;
            items[secondIndex] = firstValue;
        }
    }
}
