namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T val,Node n,Node p)
            {
                this.Value = val;
                this.Next = n;
                this.Previous = p;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.Count = 0;
            this.head = null;
            this.tail = null;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node node = new Node(item, this.head, null);
            if (this.Count == 0)
                this.tail = node;
            else
                this.head.Previous = node;
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            Node node = new Node(item, null, this.tail);
            if (this.Count == 0)
                this.head = node;
            else
                this.tail.Next = node;
            this.tail = node;
            this.Count++;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else
            {
                return this.head.Value;
            }
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else
            {
                return this.tail.Value;
            }
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else
            {
                Node head = this.head;
                if (this.Count > 1)
                    head.Next.Previous = null;
                this.head = head.Next;
                this.Count--;
                return head.Value;
            }
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else
            {
                Node tail = this.tail;
                if(this.Count>1)
                tail.Previous.Next = null;
                this.tail = tail.Previous;
                this.Count--;
                return tail.Value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node head = this.head;
            while (head!=null)
            {
                yield return head.Value;
                head = head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}