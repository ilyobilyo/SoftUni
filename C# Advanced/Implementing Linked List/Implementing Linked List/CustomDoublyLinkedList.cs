using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList
{
    public class CustomDoublyLinkedList<T>
    {
        private class Node<Tn>
        {
            public Node(Tn value)
            {
                this.Value = value;
            }

            public Tn Value { get; set; }
            public Node<Tn> Next { get; set; }
            public Node<Tn> Previous { get; set; }
        }
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new Node<T>(element);
            }
            else
            {
                var newHead = new Node<T>(element);
                newHead.Next = this.head;
                this.head.Previous = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.tail = this.head = new Node<T>(element);
            }
            else
            {
                var newTail = new Node<T>(element);
                newTail.Previous = this.tail;
                this.tail.Next = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = this.head.Value;
            this.head = this.head.Next;
            if (this.head != null)
            {
                this.head.Previous = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = this.tail.Value;
            this.tail = this.tail.Previous;
            if (this.tail != null)
            {
                this.tail.Next = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var curNode = this.head;
            while (curNode != null)
            {
                action(curNode.Value);
                curNode = curNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int counter = 0;
            var curNode = this.head;
            while (curNode != null)
            {
                array[counter++] = curNode.Value;
                curNode = curNode.Next;
            }

            return array;
        }
    }
}
