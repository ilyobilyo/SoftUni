using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            elements = new List<T>();
            Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            elements.Add(element);
            Count++;
        }

        public T Pop()
        {
            T result = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            Count--;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
