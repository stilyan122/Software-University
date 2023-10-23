namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            this.Count++;
            Node head = new Node(item, this.head, null);
            if(this.Count>1)
            this.head.Previous = head;
            this.head = head;
        }

        public void AddLast(T item)
        {
            if (this.head != null)
            {
                this.Count++;
                Node head = this.head;
                while (head.Next != null)
                {
                    head = head.Next;
                }
                head.Next = new Node(item, null, head);
            }
            else
            {
                AddFirst(item);
            }
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
                Node head = this.head;
                while (head.Next != null)
                {
                    head = head.Next;
                }
                T headValue = head.Value;
                return headValue;
            }
        }

        public T RemoveFirst()
        {
            if (this.Count==0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else
            {
                this.Count--;
                T headValue = this.head.Value;
                this.head = this.head.Next;
                return headValue;
            }
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }
            else if (this.Count > 1)
            {
                Node head = this.head;
                while (head.Next != null)
                {
                    head = head.Next;
                }
                T headValue = head.Value;
                head.Previous.Next = null;
                this.Count--;
                return headValue;
            }
            else
            {
                return RemoveFirst();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}