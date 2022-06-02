using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        public ListyIterator(List<T> list)
        {
            Elements = list;
        }

        public List<T> Elements { get; set; }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasNext()
        {
            if (index + 1 < Elements.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (Elements.Count == 0)
            {
                throw new Exception("Invalid Operation!");
            }

            Console.WriteLine(Elements[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


