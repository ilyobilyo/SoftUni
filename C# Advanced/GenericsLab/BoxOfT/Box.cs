using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    class Box<T>
    {
        int count;
        private List<T> list;
        public Box()
        {
            list = new List<T>();
            count = 0;
        }
        public int Count 
        {
            get
            {
                return count;
            }
        }

        public void Add(T element)
        {
            list.Add(element);
            count++;
        }

        public T Remove()
        {
            T value = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            count--;
            return value;
        }
    }
}
