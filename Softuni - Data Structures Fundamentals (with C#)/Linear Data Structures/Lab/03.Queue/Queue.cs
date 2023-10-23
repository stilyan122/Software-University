namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T val, Node next, Node prev)
            {
                this.Value = val;
                this.Next = next;
                this.Previous = prev;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (this.Count == 0)
            {
                Node node = new Node(item, null, null);
                this.head = node;
            }
            else
            {
                Node head = this.head;
                while (head.Next != null)
                {
                    head = head.Next;
                }
                head.Next = new Node(item, null, head);
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }
            else
            {
                Node head = this.head;
                T headValue = head.Value;
                this.head = head.Next;
                this.Count--;
                return headValue;
            }
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue empty!");
            }
            else
            {
                return this.head.Value;
            }
        }

        public bool Contains(T item)
        {
           Node head = this.head;
           while (head != null)
           {
                if (head.Value.Equals(item))
                {
                   return true;
                }
                head = head.Next;
           }
           return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node head = this.head;
            while (head != null)
            {
                yield return head.Value;
                head = head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}