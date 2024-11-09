namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        public class Node<T>
        {
            public T Value { get; set; }

            public Node<T> Next { get; set; }

            public Node<T> Previous { get; set; }

            public Node(T val, Node<T> next, Node<T> previous)
            {
                this.Value = val;
                this.Next = next;
                this.Previous = previous;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            this.Count = 0;
        }

        public void AddFirst(T item)
        {
            this.Count++;
            var node = new Node<T>(item, null, null);

            if (this.Count == 1)
            {
                this._head = this._tail = node;
                return;
            }

            var head = this._head;

            this._head.Previous = node;
            node.Next = head;
            this._head = node;
        }

        public void AddLast(T item)
        {
            this.Count++;
            var node = new Node<T>(item, null, this._tail);

            if (this.Count == 1)
            {
                this._head = this._tail = node;
                return;
            }

            this._tail.Next = node;
            this._tail = node;
        }

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }

            var head = this._head;
            return head.Value;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }

            var tail = this._tail;
            return tail.Value;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }

            if (this.Count == 1)
            {
                var node = this._head;
                this._head = this._tail = null;
                this.Count = 0;
                return node.Value;
            }

            this.Count--;
            var head = this._head;
            this._head.Next.Previous = null;
            this._head = this._head.Next;
            return head.Value;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty!");
            }

            if (this.Count == 1)
            {
                var head = this._head;
                this._head = null;
                this.Count = 0;
                return head.Value;
            }

            this.Count--;
            var tail = this._tail;
            this._tail.Previous.Next = null;
            this._tail = this._tail.Previous;
            return tail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}