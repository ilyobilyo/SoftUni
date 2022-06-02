using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            books.Sort(new BookComparator());
            for (int i = 0; i < this.books.Count; i++)
            {
                yield return this.books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        
    }

    public class LibraryIterator : IEnumerator<Book> // Ienumerator <- kakvo implementira
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public Book Current => this.books[this.currentIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose() {}

        public bool MoveNext() => ++this.currentIndex < this.books.Count;
        

        public void Reset() => this.currentIndex = -1;
    }
}
