using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    class Box<T> where T : IComparable
    {
        public Box()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }

        public int Count(T element)
        {
            int count = 0;
            foreach (var item in Items)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }

            }

            return count;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            T value = Items[firstIndex];
            Items[firstIndex] = Items[secondIndex];
            Items[secondIndex] = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}
